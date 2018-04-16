using System;

namespace Mazzsoft.CodeDBL.Core.Shared
{
    interface IColumn
    {
        String ColumnName { get; }

        String Coalesce { get; }
    }
}
