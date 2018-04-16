using System;

namespace Mazzsoft.CodeDBL.Core.Shared.Interfaces
{
    public interface ITable
    {
        String TableName { get; }

        String DefaultSortColumn { get; }

        String SchemeOwner { get; }

        String DatabaseOwner { get; }
    }
}
