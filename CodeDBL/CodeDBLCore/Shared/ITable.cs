using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDBLCore.Shared
{
    public interface ITable
    {
        String TableName { get; }

        String DefaultSortColumn { get; }

        String SchemeOwner { get; }

        String DatabaseOwner { get; }
    }
}
