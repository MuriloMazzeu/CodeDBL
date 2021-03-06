﻿using System;

namespace Mazzsoft.CodeDBL.Core.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnAttribute : Attribute, IColumn
    {
        public ColumnAttribute(String Name)
        {
            this.ColumnName = Name;
        }

        #region Required Properties

        public String ColumnName { get; private set; }

        #endregion

        public String Coalesce { get; set; }
    }
}
