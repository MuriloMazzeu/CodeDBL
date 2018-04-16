using Mazzsoft.CodeDBL.Core.Engine.Kernel;
using Mazzsoft.CodeDBL.Core.Shared.Bases;
using System;

namespace Mazzsoft.CodeDBL.Core.Engine.Statements
{
    public abstract class StatementBase : IDisposable
    {
        public delegate bool Condition<in OfTable>(OfTable entity) where OfTable : Entity;

        internal ICodeDBLConnection Connection { get; set; }

        public abstract void Dispose();

        internal TableConfigs<OfTable> GetTableConfigs<OfTable>() where OfTable : Entity
            => new TableConfigs<OfTable>();
    }
}
