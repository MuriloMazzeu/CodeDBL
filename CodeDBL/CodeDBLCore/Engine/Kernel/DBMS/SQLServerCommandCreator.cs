using CodeDBLCore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDBLCore.Engine.Kernel.DBMS
{
    internal class SQLServerCommandCreator : ICommandCreator
    {
        public String CreateSelect(string[] columns)
            => $"SELECT {String.Join(", ", columns)};";
            
        public string CreateSelectFrom<OfTable>(bool isDistinct, string[] columns, TableConfigs<OfTable> configs, uint? skip = null, uint? take = null) where OfTable : Table
        {
            var selectTop = take.HasValue && skip == null;

            var command = $"SELECT {(isDistinct ? "DISTINCT" : String.Empty)} " +
                (selectTop ? $"TOP {take.Value} " : String.Empty) +
                $"{String.Join(", ", columns)} FROM {configs.TableName}";

            if (!selectTop)
            {
                if (skip.HasValue)
                {
                    command += $" ORDER BY {configs.DefaultSortColumn}";
                    command += $" OFFSET {skip.Value} ROWS";
                }

                if (take.HasValue)
                    command += $" FETCH NEXT {take.Value} ROWS ONLY";
            }

            return $"{command};";
        }
    }
}
