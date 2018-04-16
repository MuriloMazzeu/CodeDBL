using Mazzsoft.CodeDBL.Core.Engine.Kernel;
using Mazzsoft.CodeDBL.Core.Shared.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Mazzsoft.CodeDBL.Core.Engine.Statements
{
    public class FromStatement<OfTable> : StatementBase, IEnumerable<OfTable> where OfTable : Entity
    {
        private readonly String[] Columns;
        private readonly Boolean IsDistinct;        
        private readonly Condition<OfTable> Where;
        private readonly TableConfigs<OfTable> Configs;

        internal FromStatement(ICodeDBLConnection connection, String[] columns, Boolean isDistinct)
        {
            Configs = new TableConfigs<OfTable>();
            Connection = connection;
            IsDistinct = isDistinct;
            Columns = columns;            
        }

        internal FromStatement(ICodeDBLConnection connection, String[] columns, Boolean isDistinct, Condition<OfTable> where) 
            : this(connection, columns, isDistinct) 
                => Where = where;        

        /*public JoinClause<OfTable> Join<OfTable>(Func<OfTable, Table, Boolean> on) where OfTable : EntityBase
        {
            //TODO
            return null;
        }*/

        public IEnumerator<OfTable> GetEnumerator()
        {
            var command = Connection.CommandCreator.CreateSelectFrom(IsDistinct, Columns, Configs);

            Connection.Open();
            var task = Connection.ExecuteQuery<OfTable>(command);

            while (!task.IsCompleted)
                Thread.Sleep(100);

            Connection.Close();
            foreach (var table in task.Result)
                yield return table;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override string ToString()
            => String.Join(", ", this);

        public override void Dispose()
            => Connection.Dispose();        
    }
}

