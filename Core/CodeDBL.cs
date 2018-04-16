using Mazzsoft.CodeDBL.Core.Engine;
using Mazzsoft.CodeDBL.Core.Engine.Kernel;
using Mazzsoft.CodeDBL.Core.Engine.Statements;
using Mazzsoft.CodeDBL.Core.Shared.Bases;
using Mazzsoft.CodeDBL.Core.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Mazzsoft.CodeDBL.Core
{
    public sealed class CodeDBL : ICodeDBL
    {
        #region Constructors

        /// <summary>
        /// Initialize object variables
        /// </summary>
        private CodeDBL()
        {
            IsConnected = false;
            errorsList = new List<String>();
        }

        /// <summary>
        /// Entry point to library
        /// </summary>
        public CodeDBL(DatabaseManagementSystem connectionTo, String connectionString) : this()
        {
            if (CheckConnectionString(connectionString))
            {
                Settings = new CodeDBLSettings();
                Connection = CodeDBLConnector.PrepareConnection(connectionTo, connectionString, Settings);
                IsConnected = Connection != null;
            }
        }

        #endregion

        #region Actions

        public SelectStatement Select(params string[] columns)
            => IsConnected ? new SelectStatement(Connection, columns) : null;

        public SelectStatement Select(bool distinct, params string[] columns)
            => IsConnected ? new SelectStatement(Connection, columns, distinct) : null;

        /// <summary>
        /// Not implemented!
        /// </summary>
        /// <typeparam name="Table"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public InsertStatement InsertInto<Table>(Table table) where Table : Entity
            => IsConnected ? new InsertStatement() : null;

        /// <summary>
        /// Not implemented!
        /// </summary>
        /// <typeparam name="Table"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public InsertStatement InsertInto<Table>(Table[] table) where Table : Entity
            => IsConnected ? new InsertStatement() : null;

        /// <summary>
        /// Not implemented!
        /// </summary>
        /// <typeparam name="Table"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public DeleteStatement DeleteFrom<Table>(Func<Table, Boolean> where) where Table : Entity
            => IsConnected ? new DeleteStatement() : null;


        /// <summary>
        /// Not implemented!
        /// </summary>
        /// <typeparam name="Table"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public UpdateStatement Update<Table>(Func<Table, Boolean> where) where Table : Entity
            => IsConnected ? new UpdateStatement() : null;

        private bool CheckConnectionString(String connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                errorsList.Add("The ConnectionString has no data.");
                return false;
            }


            if ((!connectionString.Contains("=")) && (!connectionString.Contains(";")))
            {
                errorsList.Add("The ConnectionString data is invalid.");
                return false;
            }

            return true;
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        public Boolean IsConnected { get; private set; }

        public String[] Errors { get => errorsList.ToArray(); }

        #region Settings

        public UInt16? Timeout {
            get => Settings.Timeout;
            set => Settings.Timeout = value ?? 500;
        }

        public String BackupTablePrefixName {
            get => Settings.BackupTablePrefixName;
            set => Settings.BackupTablePrefixName = value ?? String.Empty;
        }

        public String TemporaryTablePrefixName {
            get => Settings.TemporaryTablePrefixName;
            set => Settings.TemporaryTablePrefixName = value ?? String.Empty;
        }

        public UInt16? MaxMassiveInsertValues {
            get => Settings.MaxMassiveInsertValues;
            set => Settings.MaxMassiveInsertValues = value ?? 1000;
        }

        #endregion

        #endregion

        #region Variables and Constants

        private ICodeDBLConnection Connection;
        private readonly List<String> errorsList;
        private readonly CodeDBLSettings Settings;

        #endregion
    }
}
