
using System;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.Parity.RPC.Accounts;
using Nethereum.RPC.Eth;
using Nethereum.RPC.Tests;
using Xunit;
using Newtonsoft.Json.Linq;

namespace Nethereum.Parity.Test.Testers
{
    public class ParityAccountsInfoTester : RPCRequestTester<JObject>, IRPCRequestTester
    {
        
        [Fact]
        public async void ShouldGetInfo()
        {
            var result = await ExecuteAsync();
            Assert.NotNull(result);
        }

        public override async Task<JObject> ExecuteAsync(IClient client)
        {
            var parityAccountsInfo = new ParityAccountsInfo(client);
            return await parityAccountsInfo.SendRequestAsync();
        }

        public override Type GetRequestType()
        {
            return typeof(ParityAccountsInfo);
        }
    }
}
        