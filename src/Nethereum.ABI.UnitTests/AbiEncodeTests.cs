using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Hex.HexConvertors.Extensions;
using Xunit;

namespace Nethereum.ABI.UnitTests
{
    public class AbiEncodeTests
    {
        [Fact]
        public virtual void ShouldEncodeMultipleTypesIncludingDynamicString()
        {
            var paramsEncoded =
                "0000000000000000000000000000000000000000000000000000000000000060000000000000000000000000000000000000000000000000000000000000004500000000000000000000000000000000000000000000000000000000000000a0000000000000000000000000000000000000000000000000000000000000000568656c6c6f0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005776f726c64000000000000000000000000000000000000000000000000000000";
            var abiEncode = new ABIEncode();
            var result = abiEncode.GetABIEncoded(new ABIValue("string", "hello"), new ABIValue("int", 69),
                new ABIValue("string", "world"));

            Assert.Equal("0x" + paramsEncoded, result.ToHex(true));
        }

        [Fact]
        public virtual void ShouldEncodeParams()
        {
            var paramsEncoded =
                "0000000000000000000000000000000000000000000000000000000000000060000000000000000000000000000000000000000000000000000000000000004500000000000000000000000000000000000000000000000000000000000000a0000000000000000000000000000000000000000000000000000000000000000568656c6c6f0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005776f726c64000000000000000000000000000000000000000000000000000000";
            var abiEncode = new ABIEncode();
            var result = abiEncode.GetABIParamsEncoded(new TestParamsInput(){First = "hello", Second = 69, Third = "world"});
            Assert.Equal("0x" + paramsEncoded, result.ToHex(true));
        }
        public class TestParamsInput
        {
            [Parameter("string", 1)]
            public string First { get; set; }
            [Parameter("int256", 2)]
            public int Second { get; set; }
            [Parameter("string", 3)]
            public string Third { get; set; }
        }

    }
}