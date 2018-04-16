using System;

namespace Mazzsoft.CodeDBL.Core.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TableAttribute : Attribute, ITable
    {
        public TableAttribute(String Name, String DefaultSortColumn)
        {
            this.TableName = Name;
            this.DefaultSortColumn = DefaultSortColumn;
        }

        #region Required Properties

        public String TableName { get; private set; }

        public String DefaultSortColumn { get; private set; }

        #endregion;

        public String SchemeOwner { get; set; }

        public String DatabaseOwner { get; set; }
    }
}
