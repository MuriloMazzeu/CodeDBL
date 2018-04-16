using CodeDBLCore.Shared;
using System.Collections.Generic;
using System.Reflection;

namespace CodeDBLCore.Engine.Kernel
{
    internal class TableConfigs<OfTable> : ITable where OfTable : Table
    {
        private readonly List<ColumnConfigs> columnConfigs;

        internal TableConfigs()
        {
            MemberInfo info = typeof(OfTable);
            columnConfigs = new List<ColumnConfigs>();            
            var tableAttr = info.GetCustomAttribute<TableAttribute>(true);
            var methods = typeof(OfTable).GetMethods(BindingFlags.GetProperty);

            TableName = tableAttr.TableName;
            SchemeOwner = tableAttr.SchemeOwner;
            DatabaseOwner = tableAttr.DatabaseOwner;            
            DefaultSortColumn = tableAttr.DefaultSortColumn;

            foreach(var method in methods)
            {
                var columnAttr = method.GetCustomAttribute<ColumnAttribute>(true);
                columnConfigs.Add(new ColumnConfigs(columnAttr.ColumnName, columnAttr.Coalesce));
            }           
        }

        public string TableName { get; private set; }

        public string DefaultSortColumn { get; private set; }

        public string SchemeOwner { get; private set; }

        public string DatabaseOwner { get; private set; }

        public ColumnConfigs[] ColumnConfigs { get => columnConfigs.ToArray(); }
    }
}
