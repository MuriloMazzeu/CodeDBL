using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDBLCore.Shared
{
    interface IColumn
    {
        String ColumnName { get; }

        String Coalesce { get; }
    }
}
