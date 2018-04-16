using CodeDBLCore.Shared;

namespace Mazzsoft.CodeDBL.Core.Engine.Kernel
{
    internal class ColumnConfigs : IColumn
    {
        internal ColumnConfigs(string columnName, string coalesce)
        {
            ColumnName = columnName;
            Coalesce = coalesce;
        }

        public string ColumnName { get; private set; }

        public string Coalesce { get; private set; }
    }
}
