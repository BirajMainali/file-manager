using System.Transactions;

namespace FileManager.Application.Helper;

public static class TransactionScopeHelper
{
    public static TransactionScope Scope()
    {
        return new(TransactionScopeAsyncFlowOption.Enabled);
    }
}