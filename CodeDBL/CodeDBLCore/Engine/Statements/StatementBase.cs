using CodeDBLCore.Engine.Kernel;
using CodeDBLCore.Kernel;
using CodeDBLCore.Shared;
using System;

namespace CodeDBLCore.Engine.Statements
{
    public abstract class StatementBase : IDisposable
    {
        public delegate bool Condition<in OfTable>(OfTable entity) where OfTable : Table;

        internal ICodeDBLConnection Connection { get; set; }

        public abstract void Dispose();

        internal TableConfigs<OfTable> GetTableConfigs<OfTable>() where OfTable : Table
            => new TableConfigs<OfTable>();
    }
}
