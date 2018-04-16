using Mazzsoft.CodeDBL.Core.Engine.Kernel.DBMS;
using Mazzsoft.CodeDBL.Core.Shared.Enums;
using System;
namespace Mazzsoft.CodeDBL.Core.Engine.Kernel
{
    internal static class CodeDBLConnector
    {        
        public static ICodeDBLConnection PrepareConnection(DatabaseManagementSystem dbms, String connectionString, CodeDBLSettings settings)
        {
            switch (dbms)
            {
                case DatabaseManagementSystem.SQLServer:
                    return new SQLServerConnection(connectionString, settings);

                case DatabaseManagementSystem.MariaDB:
                    return null;// new MariaDBConnection(connectionString, settings);

                case DatabaseManagementSystem.MySQL:
                    return null;// new MySQLConnection(connectionString, settings);

                default: return null;
            }
        }

    }
}