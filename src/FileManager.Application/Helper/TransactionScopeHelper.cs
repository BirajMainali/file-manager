using System.Transactions;

namespace FileManager.Application.Helper
{
    public static class TransactionScopeHelper
    {
        public static TransactionScope Scope() 
            => new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    }
}