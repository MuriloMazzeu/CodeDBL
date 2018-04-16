using Mazzsoft.CodeDBL.Core.Engine.Statements;
using Mazzsoft.CodeDBL.Core.Shared.Bases;
using System;

namespace Mazzsoft.CodeDBL.Core.Engine
{
    public interface ICodeDBL
    {
        #region DML

        SelectStatement Select(string[] columns);

        InsertStatement InsertInto<Table>(Table entity) where Table : Entity;

        InsertStatement InsertInto<Table>(Table[] entities) where Table : Entity;

        UpdateStatement Update<Table>(Func<Table, Boolean> where) where Table : Entity;

        DeleteStatement DeleteFrom<Table>(Func<Table, Boolean> where) where Table : Entity;

        #endregion

        #region DDL
        /*
                #region Adds
                bool AddColumn(string table, string column, string type);

                bool AddPrimaryKey(string table, string column);

                bool AddPrimaryKey(string table, string[] column);

                bool AddForeignKey(string table, string foreignTable, string column);

                bool AddForeignKey(string table, string foreignTable, string[] column);

                bool AddIndexKey(string table, string foreignTable, string column);

                bool AddIndexKey(string table, string foreignTable, string[] column);

                bool AddUniqueKey(string table, string foreignTable, string column);

                bool AddUniqueKey(string table, string foreignTable, string[] column);
                #endregion

                #region Drops

                bool DropColumn(string table, string column);

                bool DropPrimaryKey(string table);

                bool DropForeignKey(string table, string column);

                bool DropIndexKey(string table, string column);

                bool DropFunction(string function);

                bool DropUniqueKey(string table, string column);

                bool DropTable(string table);

                void TruncateTable(string table);

                bool DropView(string table);

                bool DropProcedure(string table);

                bool DropTrigger(string table);
                #endregion

                #region Creates

                bool CreateTable();

                bool CreateView();

                bool CreateProcedure();

                bool CreateFunction();

                bool CreateTrigger();
                #endregion

                #region Miscellaneous

                bool SetConfig(string config, string value);

                void CallProcedure(string procedure, string[] args);

                bool ViewExists(string view);

                bool TableExists(string table);

                bool ColumnExists(string table, string column);

                bool TriggerExists(string trigger);

                bool StoredProcedureExists(string sp);

                bool FunctionExists(string function);

                bool DatabaseExists(string database);

                #endregion

                #region Transactions
                    SqlTransaction BeginTransaction(SqlConnection link);

                    void EndTransaction(SqlTransaction transaction);

                    void CommitTransaction(SqlTransaction transaction);

                    void RollbackTransaction(SqlTransaction transaction);

                    void SaveTransaction(SqlTransaction transaction);
                #endregion
        */
        #endregion

    }
}
