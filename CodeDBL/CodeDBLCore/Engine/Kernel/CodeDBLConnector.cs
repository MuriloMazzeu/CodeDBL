using CodeDBLCore.Engine.Kernel.DBMS;
using CodeDBLCore.Kernel;
using System;
namespace CodeDBLCore.Engine.Kernel
{
    internal static class CodeDBLConnector
    {        
        public static ICodeDBLConnection PrepareConnection(Shared.DBMS dbms, String connectionString, CodeDBLSettings settings)
        {
            switch (dbms)
            {
                case Shared.DBMS.SQLServer:
                    return new SQLServerConnection(connectionString, settings);

                case Shared.DBMS.MariaDB:
                    return null;// new MariaDBConnection(connectionString, settings);

                case Shared.DBMS.MySQL:
                    return null;// new MySQLConnection(connectionString, settings);

                default: return null;
            }
        }

    }
}