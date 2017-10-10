﻿using System;
using System.Linq;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer.Crypto;
using Nethereum.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Crypto.Agreement;

namespace Nethereum.Signer
{
    public class EthECKey
    {
        private static readonly SecureRandom SecureRandom = new SecureRandom();
        private readonly ECKey _ecKey;
        public static byte DEFAULT_PREFIX = 0x04;

        public EthECKey(string privateKey)
        {
            _ecKey = new ECKey(privateKey.HexToByteArray(), true);            
        }


        public EthECKey(byte[] vch, bool isPrivate)
        {
      
             _ecKey = new ECKey(vch, isPrivate);
            
        }

        public EthECKey(byte[] vch, bool isPrivate, byte prefix)
        {
             _ecKey = new ECKey(ByteUtil.Merge(new byte[] { prefix }, vch), isPrivate); 
        }

        internal EthECKey(ECKey ecKey)
        {
            _ecKey = ecKey;
        }


        public byte[] CalculateCommonSecret(EthECKey publicKey)
        {
            var agreement = new ECDHBasicAgreement();
            agreement.Init(this._ecKey.PrivateKey);
            var z =  agreement.CalculateAgreement(publicKey._ecKey.GetPublicKeyParameters());
     
            return Org.BouncyCastle.Utilities.BigIntegers.AsUnsignedByteArray(agreement.GetFieldSize(), z);
        }


        internal int CalculateRecId(ECDSASignature signature, byte[] hash)
        {
            var recId = -1;
            var thisKey = _ecKey.GetPubKey(false); // compressed

            for (var i = 0; i < 4; i++)
            {
                var rec = ECKey.RecoverFromSignature(i, signature, hash, false);
                if (rec != null) {
                    var k = rec.GetPubKey(false);
                    if ((k != null) && k.SequenceEqual(thisKey))
                    {
                        recId = i;
                        break;
                    }
                }
            }
            if (recId == -1)
                throw new Exception("Could not construct a recoverable key. This should never happen.");
            return recId;
        }

        public static EthECKey GenerateKey()
        { 
            var gen = new ECKeyPairGenerator("EC");
            var keyGenParam = new KeyGenerationParameters(SecureRandom, 256);
            gen.Init(keyGenParam);
            var keyPair = gen.GenerateKeyPair();
            var privateBytes = ((ECPrivateKeyParameters) keyPair.Private).D.ToByteArray();
            if (privateBytes.Length != 32)
            {
                return GenerateKey();
            }
            return new EthECKey(privateBytes, true);
        }

        public byte[] GetPrivateKeyAsBytes()
        {
            return _ecKey.PrivateKey.D.ToByteArray();
        }

        public string GetPrivateKey()
        {
            return GetPrivateKeyAsBytes().ToHex(true);
        }

        public byte[] GetPubKey()
        {
            return _ecKey.GetPubKey(false);
        }

        public byte[] GetPubKeyNoPrefix()
        {
            var pubKey = _ecKey.GetPubKey(false);
            var arr = new byte[pubKey.Length - 1];
            //remove the prefix
            Array.Copy(pubKey, 1, arr, 0, arr.Length);
            return arr;
        }

        public string GetPublicAddress()
        {
            var initaddr = new Sha3Keccack().CalculateHash(GetPubKeyNoPrefix());
            var addr = new byte[initaddr.Length - 12];
            Array.Copy(initaddr, 12, addr, 0, initaddr.Length - 12);
            return new AddressUtil().ConvertToChecksumAddress(addr.ToHex());
        }

        public static string GetPublicAddress(string privateKey)
        {
            var key = new EthECKey(privateKey.HexToByteArray(), true);
            return key.GetPublicAddress();
        }

        public static int GetRecIdFromV(byte v)
        {
            var header = v;
            // The header byte: 0x1B = first key with even y, 0x1C = first key with odd y,
            //                  0x1D = second key with even y, 0x1E = second key with odd y
            if ((header < 27) || (header > 34))
                throw new Exception("Header byte out of range: " + header);
            if (header >= 31)
                header -= 4;
            return header - 27;
        }

        public static EthECKey RecoverFromSignature(EthECDSASignature signature, byte[] hash)
        {
            return new EthECKey(ECKey.RecoverFromSignature(GetRecIdFromV(signature.V), signature.ECDSASignature, hash, false));
        }

        public static EthECKey RecoverFromSignature(EthECDSASignature signature, int recId, byte[] hash)
        {
            return new EthECKey(ECKey.RecoverFromSignature(recId, signature.ECDSASignature, hash, false));
        }

        public EthECDSASignature SignAndCalculateV(byte[] hash)
        {
            var signature = _ecKey.Sign(hash);
            var recId = CalculateRecId(signature, hash);
            signature.V = (byte) (recId + 27);
            return new EthECDSASignature(signature);
        }

        public EthECDSASignature Sign(byte[] hash)
        {
            var signature = _ecKey.Sign(hash);
            return new EthECDSASignature(signature);
        }

        public bool Verify(byte[] hash, EthECDSASignature sig)
        {
            return _ecKey.Verify(hash, sig.ECDSASignature);
        }

        public bool VerifyAllowingOnlyLowS(byte[] hash, EthECDSASignature sig)
        {
            if (!sig.IsLowS) return false;
            return _ecKey.Verify(hash, sig.ECDSASignature);
        }
    }

}