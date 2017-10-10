using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Xunit;

namespace Nethereum.Web3.Tests
{
  
    //Note: Dao tests are not valid after the fork
    public class DaoTest
    {

        //[Fact]
        public async void GetBlock()
        {
            var web3 = new Web3(ClientFactory.GetClient());
            var block = await web3.Eth.Blocks.GetBlockWithTransactionsHashesByNumber.SendRequestAsync(new HexBigInteger(1139657));
            var transaction =
                await
                    web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(
                        "0x9122a4bba873e30c9c6e71481bd60ef61f559f60e26e50a38272f3324b7befca");

            var receipt = await
                web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(
                    "0x9122a4bba873e30c9c6e71481bd60ef61f559f60e26e50a38272f3324b7befca");
           
        }
        //0x2e3b02a91f1115812b518c35149bbb54b788ea1c25c45abb7d477556ef20ac96
        //Note: These tests are pointing to live.   

        //[Fact]
        public void CheckTotalSupply()
        {
            var abi =
                @"[{ ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""name"": ""proposals"", ""outputs"": [{ ""name"": ""recipient"", ""type"": ""address"" }, { ""name"": ""amount"", ""type"": ""uint256"" }, { ""name"": ""description"", ""type"": ""string"" }, { ""name"": ""votingDeadline"", ""type"": ""uint256"" }, { ""name"": ""open"", ""type"": ""bool"" }, { ""name"": ""proposalPassed"", ""type"": ""bool"" }, { ""name"": ""proposalHash"", ""type"": ""bytes32"" }, { ""name"": ""proposalDeposit"", ""type"": ""uint256"" }, { ""name"": ""newCurator"", ""type"": ""bool"" }, { ""name"": ""yea"", ""type"": ""uint256"" }, { ""name"": ""nay"", ""type"": ""uint256"" }, { ""name"": ""creator"", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_spender"", ""type"": ""address"" }, { ""name"": ""_amount"", ""type"": ""uint256"" }], ""name"": ""approve"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""minTokensToCreate"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""rewardAccount"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""daoCreator"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""totalSupply"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""divisor"", ""outputs"": [{ ""name"": ""divisor"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""extraBalance"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_transactionData"", ""type"": ""bytes"" }], ""name"": ""executeProposal"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_from"", ""type"": ""address"" }, { ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transferFrom"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""unblockMe"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""totalRewardToken"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""actualBalance"", ""outputs"": [{ ""name"": ""_actualBalance"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""closingTime"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""allowedRecipients"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transferWithoutReward"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""refund"", ""outputs"": [], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_recipient"", ""type"": ""address"" }, { ""name"": ""_amount"", ""type"": ""uint256"" }, { ""name"": ""_description"", ""type"": ""string"" }, { ""name"": ""_transactionData"", ""type"": ""bytes"" }, { ""name"": ""_debatingPeriod"", ""type"": ""uint256"" }, { ""name"": ""_newCurator"", ""type"": ""bool"" }], ""name"": ""newProposal"", ""outputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""DAOpaidOut"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""minQuorumDivisor"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_newContract"", ""type"": ""address"" }], ""name"": ""newContract"", ""outputs"": [], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_owner"", ""type"": ""address"" }], ""name"": ""balanceOf"", ""outputs"": [{ ""name"": ""balance"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_recipient"", ""type"": ""address"" }, { ""name"": ""_allowed"", ""type"": ""bool"" }], ""name"": ""changeAllowedRecipients"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""halveMinQuorum"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""paidOut"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_newCurator"", ""type"": ""address"" }], ""name"": ""splitDAO"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""DAOrewardAccount"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""proposalDeposit"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""numberOfProposals"", ""outputs"": [{ ""name"": ""_numberOfProposals"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""lastTimeMinQuorumMet"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_toMembers"", ""type"": ""bool"" }], ""name"": ""retrieveDAOReward"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""receiveEther"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transfer"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""isFueled"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_tokenHolder"", ""type"": ""address"" }], ""name"": ""createTokenProxy"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }], ""name"": ""getNewDAOAddress"", ""outputs"": [{ ""name"": ""_newDAO"", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_supportsProposal"", ""type"": ""bool"" }], ""name"": ""vote"", ""outputs"": [{ ""name"": ""_voteID"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""getMyReward"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""rewardToken"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_from"", ""type"": ""address"" }, { ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transferFromWithoutReward"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_owner"", ""type"": ""address"" }, { ""name"": ""_spender"", ""type"": ""address"" }], ""name"": ""allowance"", ""outputs"": [{ ""name"": ""remaining"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalDeposit"", ""type"": ""uint256"" }], ""name"": ""changeProposalDeposit"", ""outputs"": [], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""blocked"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""curator"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_recipient"", ""type"": ""address"" }, { ""name"": ""_amount"", ""type"": ""uint256"" }, { ""name"": ""_transactionData"", ""type"": ""bytes"" }], ""name"": ""checkProposalCode"", ""outputs"": [{ ""name"": ""_codeChecksOut"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""privateCreation"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""inputs"": [{ ""name"": ""_curator"", ""type"": ""address"" }, { ""name"": ""_daoCreator"", ""type"": ""address"" }, { ""name"": ""_proposalDeposit"", ""type"": ""uint256"" }, { ""name"": ""_minTokensToCreate"", ""type"": ""uint256"" }, { ""name"": ""_closingTime"", ""type"": ""uint256"" }, { ""name"": ""_privateCreation"", ""type"": ""address"" }], ""type"": ""constructor"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_from"", ""type"": ""address"" }, { ""indexed"": true, ""name"": ""_to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_amount"", ""type"": ""uint256"" }], ""name"": ""Transfer"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_owner"", ""type"": ""address"" }, { ""indexed"": true, ""name"": ""_spender"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_amount"", ""type"": ""uint256"" }], ""name"": ""Approval"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": false, ""name"": ""value"", ""type"": ""uint256"" }], ""name"": ""FuelingToDate"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""amount"", ""type"": ""uint256"" }], ""name"": ""CreatedToken"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""value"", ""type"": ""uint256"" }], ""name"": ""Refund"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""proposalID"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""recipient"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""amount"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""newCurator"", ""type"": ""bool"" }, { ""indexed"": false, ""name"": ""description"", ""type"": ""string"" }], ""name"": ""ProposalAdded"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""proposalID"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""position"", ""type"": ""bool"" }, { ""indexed"": true, ""name"": ""voter"", ""type"": ""address"" }], ""name"": ""Voted"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""proposalID"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""result"", ""type"": ""bool"" }, { ""indexed"": false, ""name"": ""quorum"", ""type"": ""uint256"" }], ""name"": ""ProposalTallied"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_newCurator"", ""type"": ""address"" }], ""name"": ""NewCurator"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_recipient"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_allowed"", ""type"": ""bool"" }], ""name"": ""AllowedRecipientChanged"", ""type"": ""event"" }]";
            var contractAddress = "0xbb9bc244d798123fde783fcc1c72d3bb8c189413";
            var web3 = new Web3();
            var contract = web3.Eth.GetContract(abi, contractAddress);
            var totalSupplyFunction = contract.GetFunction("totalSupply");
            var result = totalSupplyFunction.CallAsync<BigInteger>().Result;
            Assert.True(result > 0);
        }

        //[Fact]
        public void CheckProposal()
        {
            var abi =
                @"[{ ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""name"": ""proposals"", ""outputs"": [{ ""name"": ""recipient"", ""type"": ""address"" }, { ""name"": ""amount"", ""type"": ""uint256"" }, { ""name"": ""description"", ""type"": ""string"" }, { ""name"": ""votingDeadline"", ""type"": ""uint256"" }, { ""name"": ""open"", ""type"": ""bool"" }, { ""name"": ""proposalPassed"", ""type"": ""bool"" }, { ""name"": ""proposalHash"", ""type"": ""bytes32"" }, { ""name"": ""proposalDeposit"", ""type"": ""uint256"" }, { ""name"": ""newCurator"", ""type"": ""bool"" }, { ""name"": ""yea"", ""type"": ""uint256"" }, { ""name"": ""nay"", ""type"": ""uint256"" }, { ""name"": ""creator"", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_spender"", ""type"": ""address"" }, { ""name"": ""_amount"", ""type"": ""uint256"" }], ""name"": ""approve"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""minTokensToCreate"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""rewardAccount"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""daoCreator"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""totalSupply"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""divisor"", ""outputs"": [{ ""name"": ""divisor"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""extraBalance"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_transactionData"", ""type"": ""bytes"" }], ""name"": ""executeProposal"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_from"", ""type"": ""address"" }, { ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transferFrom"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""unblockMe"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""totalRewardToken"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""actualBalance"", ""outputs"": [{ ""name"": ""_actualBalance"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""closingTime"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""allowedRecipients"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transferWithoutReward"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""refund"", ""outputs"": [], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_recipient"", ""type"": ""address"" }, { ""name"": ""_amount"", ""type"": ""uint256"" }, { ""name"": ""_description"", ""type"": ""string"" }, { ""name"": ""_transactionData"", ""type"": ""bytes"" }, { ""name"": ""_debatingPeriod"", ""type"": ""uint256"" }, { ""name"": ""_newCurator"", ""type"": ""bool"" }], ""name"": ""newProposal"", ""outputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""DAOpaidOut"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""minQuorumDivisor"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_newContract"", ""type"": ""address"" }], ""name"": ""newContract"", ""outputs"": [], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_owner"", ""type"": ""address"" }], ""name"": ""balanceOf"", ""outputs"": [{ ""name"": ""balance"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_recipient"", ""type"": ""address"" }, { ""name"": ""_allowed"", ""type"": ""bool"" }], ""name"": ""changeAllowedRecipients"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""halveMinQuorum"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""paidOut"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_newCurator"", ""type"": ""address"" }], ""name"": ""splitDAO"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""DAOrewardAccount"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""proposalDeposit"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""numberOfProposals"", ""outputs"": [{ ""name"": ""_numberOfProposals"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""lastTimeMinQuorumMet"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_toMembers"", ""type"": ""bool"" }], ""name"": ""retrieveDAOReward"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""receiveEther"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transfer"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""isFueled"", ""outputs"": [{ ""name"": """", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_tokenHolder"", ""type"": ""address"" }], ""name"": ""createTokenProxy"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }], ""name"": ""getNewDAOAddress"", ""outputs"": [{ ""name"": ""_newDAO"", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_supportsProposal"", ""type"": ""bool"" }], ""name"": ""vote"", ""outputs"": [{ ""name"": ""_voteID"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""getMyReward"", ""outputs"": [{ ""name"": ""_success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""rewardToken"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_from"", ""type"": ""address"" }, { ""name"": ""_to"", ""type"": ""address"" }, { ""name"": ""_value"", ""type"": ""uint256"" }], ""name"": ""transferFromWithoutReward"", ""outputs"": [{ ""name"": ""success"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_owner"", ""type"": ""address"" }, { ""name"": ""_spender"", ""type"": ""address"" }], ""name"": ""allowance"", ""outputs"": [{ ""name"": ""remaining"", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": false, ""inputs"": [{ ""name"": ""_proposalDeposit"", ""type"": ""uint256"" }], ""name"": ""changeProposalDeposit"", ""outputs"": [], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": """", ""type"": ""address"" }], ""name"": ""blocked"", ""outputs"": [{ ""name"": """", ""type"": ""uint256"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""curator"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [{ ""name"": ""_proposalID"", ""type"": ""uint256"" }, { ""name"": ""_recipient"", ""type"": ""address"" }, { ""name"": ""_amount"", ""type"": ""uint256"" }, { ""name"": ""_transactionData"", ""type"": ""bytes"" }], ""name"": ""checkProposalCode"", ""outputs"": [{ ""name"": ""_codeChecksOut"", ""type"": ""bool"" }], ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""privateCreation"", ""outputs"": [{ ""name"": """", ""type"": ""address"" }], ""type"": ""function"" }, { ""inputs"": [{ ""name"": ""_curator"", ""type"": ""address"" }, { ""name"": ""_daoCreator"", ""type"": ""address"" }, { ""name"": ""_proposalDeposit"", ""type"": ""uint256"" }, { ""name"": ""_minTokensToCreate"", ""type"": ""uint256"" }, { ""name"": ""_closingTime"", ""type"": ""uint256"" }, { ""name"": ""_privateCreation"", ""type"": ""address"" }], ""type"": ""constructor"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_from"", ""type"": ""address"" }, { ""indexed"": true, ""name"": ""_to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_amount"", ""type"": ""uint256"" }], ""name"": ""Transfer"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_owner"", ""type"": ""address"" }, { ""indexed"": true, ""name"": ""_spender"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_amount"", ""type"": ""uint256"" }], ""name"": ""Approval"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": false, ""name"": ""value"", ""type"": ""uint256"" }], ""name"": ""FuelingToDate"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""amount"", ""type"": ""uint256"" }], ""name"": ""CreatedToken"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""value"", ""type"": ""uint256"" }], ""name"": ""Refund"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""proposalID"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""recipient"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""amount"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""newCurator"", ""type"": ""bool"" }, { ""indexed"": false, ""name"": ""description"", ""type"": ""string"" }], ""name"": ""ProposalAdded"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""proposalID"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""position"", ""type"": ""bool"" }, { ""indexed"": true, ""name"": ""voter"", ""type"": ""address"" }], ""name"": ""Voted"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""proposalID"", ""type"": ""uint256"" }, { ""indexed"": false, ""name"": ""result"", ""type"": ""bool"" }, { ""indexed"": false, ""name"": ""quorum"", ""type"": ""uint256"" }], ""name"": ""ProposalTallied"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_newCurator"", ""type"": ""address"" }], ""name"": ""NewCurator"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [{ ""indexed"": true, ""name"": ""_recipient"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_allowed"", ""type"": ""bool"" }], ""name"": ""AllowedRecipientChanged"", ""type"": ""event"" }]";
            var contractAddress = "0xbb9bc244d798123fde783fcc1c72d3bb8c189413";
            var web3 = new Web3();
            var contract = web3.Eth.GetContract(abi, contractAddress);
            var proposalsFunction = contract.GetFunction("proposals");
            var result = proposalsFunction.CallDeserializingToObjectAsync<Proposal>(5).Result;
            Assert.True(result.Creator == "0xd68ba7734753e2ee54103116323aba2d94c78dc5");
        }

        /*
         "outputs":[  
         {  
            "name":"recipient",
            "type":"address"
         },
         {  
            "name":"amount",
            "type":"uint256"
         },
         {  
            "name":"description",
            "type":"string"
         },
         {  
            "name":"votingDeadline",
            "type":"uint256"
         },
         {  
            "name":"open",
            "type":"bool"
         },
         {  
            "name":"proposalPassed",
            "type":"bool"
         },
         {  
            "name":"proposalHash",
            "type":"bytes32"
         },
         {  
            "name":"proposalDeposit",
            "type":"uint256"
         },
         {  
            "name":"newCurator",
            "type":"bool"
         },
         {  
            "name":"yea",
            "type":"uint256"
         },
         {  
            "name":"nay",
            "type":"uint256"
         },
         {  
            "name":"creator",
            "type":"address"
         }
      ],

        */
        [FunctionOutput]
        public class Proposal
        {
            [Parameter("address", 1)]
            public string Recipient { get; set; }

            [Parameter("uint256", 2)]
            public BigInteger Amount { get; set; }

            [Parameter("string", 3)]
            public string Description { get; set; }

            [Parameter("uint256", 4)]
            public BigInteger VotingDeadline { get; set; }

            [Parameter("bool", 5)]
            public bool Open { get; set; }

            [Parameter("bool", 6)]
            public bool ProposalPassed { get; set; }

            [Parameter("bytes32", 7)]
            public byte[] ProposalHash { get; set; }

            public string GetProposalHashToHex()
            {
                return ProposalHash.ToHex();
            }

            [Parameter("uint256", 8)]
            public BigInteger ProposalDeposit { get; set; }

            [Parameter("bool", 9)]
            public bool NewCurator { get; set; }

            [Parameter("uint256", 10)]
            public BigInteger Yea { get; set; }

            [Parameter("uint256", 11)]
            public BigInteger Nay { get; set; }

            [Parameter("address", 12)]
            public string Creator { get; set; }
        }
    }

}