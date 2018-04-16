using Mazzsoft.CodeDBL.Core.Shared.Bases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mazzsoft.CodeDBL.Core.Engine.Kernel.DBMS
{
    internal class SQLServerConnection : ICodeDBLConnection
    {
        private readonly SqlConnection Connection;
        private readonly CodeDBLSettings Settings;

        public ICommandCreator CommandCreator { get => new SQLServerCommandCreator(); }

        internal SQLServerConnection(String credentials, CodeDBLSettings settings)
        {
            Connection = new SqlConnection(credentials);
            Settings = settings;
        }

        public void Dispose()
            => Connection.Dispose();

        public void Open()
            => Connection.Open();
                

        public void Close()
        {
            Connection.Close();
            Dispose();
        }

        public async void ExecuteNonQueries(params Action<Task>[] queries)
        {
            var task = Connection.OpenAsync();
            foreach (var query in queries)
                task = task.ContinueWith(query);

            await task.ContinueWith(t => Close());
        }

        public async void ExecuteNonQuery(string sql)
        {
            using(var command = Connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandTimeout = Settings.Timeout;
                command.Prepare();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<KeyValuePair<String, Object>>> ExecuteSingleRowQuery(string tsql)
        {
            using(var command = Connection.CreateCommand())
            {
                command.CommandText = tsql;
                command.CommandTimeout = Settings.Timeout;
                command.Prepare();
                
                using(var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                {
                    if (reader.HasRows)
                    {

                        return null;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                    
                }
            }
        }

        public async Task<IEnumerable<OfTable>> ExecuteQuery<OfTable>(string tsql) where OfTable : Entity
        {

            using (var command = Connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandTimeout = Settings.Timeout;
                command.Prepare();

                var r = command.BeginExecuteReader();
                command.EndExecuteReader(r);
            }
            return null;
        }

        public async Task<IEnumerable<OfTable>[]> ExecuteQueries<OfTable>(params Func<Task<IEnumerable<OfTable>>>[] queires) where OfTable : Entity
        {
            var results = new List<IEnumerable<OfTable>>();
            var task = Connection.OpenAsync();

            foreach (var query in queires)
                task = task.ContinueWith(async t => { results.Add(await query()); });

            await task.ContinueWith(t => Close());
            return results.ToArray();
        }
    }
}
