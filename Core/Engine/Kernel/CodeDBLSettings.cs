using System;

namespace Mazzsoft.CodeDBL.Core.Engine.Kernel
{
    internal class CodeDBLSettings
    {
        public UInt16 Timeout { get; set; }

        public String BackupTablePrefixName { get; set; }

        public UInt16 MaxMassiveInsertValues { get; set; }

        public String TemporaryTablePrefixName { get; set; }              
    }
}
