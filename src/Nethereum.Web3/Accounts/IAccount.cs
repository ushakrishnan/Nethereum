﻿using Nethereum.RPC.TransactionManagers;

namespace Nethereum.Web3.Accounts
{
    public interface IAccount
    {
        string Address { get; }
        ITransactionManager TransactionManager { get; }
    }
}