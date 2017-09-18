using CodeDBLCore.Engine.Kernel;
using CodeDBLCore.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeDBLCore.Kernel
{
    internal interface ICodeDBLConnection : IDisposable
    {
        ICommandCreator CommandCreator { get; }

        void Open();        

        void Close();

        void ExecuteNonQuery(string sql);                

        void ExecuteNonQueries(params Action<Task>[] queries);

        Task<IEnumerable<KeyValuePair<String, Object>>> ExecuteSingleRowQuery(string sql);

        Task<IEnumerable<OfTable>> ExecuteQuery<OfTable>(string sql) where OfTable : Table;

        Task<IEnumerable<OfTable>[]> ExecuteQueries<OfTable>(params Func<Task<IEnumerable<OfTable>>>[] queires) where OfTable : Table;
    }
}
