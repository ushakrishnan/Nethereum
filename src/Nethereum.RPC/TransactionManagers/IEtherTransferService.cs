﻿using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.RPC.Eth.DTOs;

namespace Nethereum.RPC.TransactionManagers
{
    public interface IEtherTransferService
    {
        Task<TransactionReceipt> TransferEtherAndWaitForReceiptAsync(string toAddress, decimal etherAmount, decimal? gasPriceGwei = null, BigInteger? gas = null, CancellationTokenSource tokenSource = null, BigInteger? nonce = null);
        Task<string> TransferEtherAsync(string toAddress, decimal etherAmount, decimal? gasPriceGwei = null, BigInteger? gas = null, BigInteger? nonce = null);
        Task<decimal> CalculateTotalAmountToTransferWholeBalanceInEther(string address, decimal gasPriceGwei, BigInteger? gas = null);
        Task<BigInteger> EstimateGasAsync(string toAddress, decimal etherAmount);
    }
}