using Mazzsoft.CodeDBL.Core.Engine.Kernel;
using Mazzsoft.CodeDBL.Core.Shared.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Mazzsoft.CodeDBL.Core.Engine.Statements
{
    public class SelectStatement : StatementBase, IEnumerable<KeyValuePair<String, Object>>
    {
        private readonly String[] Columns;
        private readonly Boolean IsDistinct;

        internal SelectStatement(ICodeDBLConnection connection, String[] columns, bool distinct = false)
        {
            Columns = columns;
            IsDistinct = distinct;
            Connection = connection;
        }

        public IEnumerator<KeyValuePair<String, Object>> GetEnumerator()
        {
            var command = Connection.CommandCreator.CreateSelect(Columns);

            Connection.Open();
            var task = Connection.ExecuteSingleRowQuery(command);

            while (!task.IsCompleted)
                Thread.Sleep(100);

            Connection.Close();
            foreach (var row in task.Result)
                yield return row;
        }

        public FromStatement<OfTable> From<OfTable>() where OfTable : Entity
            => new FromStatement<OfTable>(Connection, Columns, IsDistinct);

        public FromStatement<OfTable> From<OfTable>(Condition<OfTable> where) where OfTable : Entity
            => new FromStatement<OfTable>(Connection, Columns, IsDistinct, where);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override string ToString()
            => String.Join(", ", this);

        public override void Dispose()
            => Connection.Dispose();        
    }
}
