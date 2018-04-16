using Mazzsoft.CodeDBL.Core.Shared.Bases;

namespace Mazzsoft.CodeDBL.Core.Engine.Kernel
{
    internal interface ICommandCreator
    {
        /// <summary>
        /// Simple Selects without tables or views
        /// </summary>
        /// <param name="columns">Columns of single row result</param>
        /// <returns></returns>
        string CreateSelect(string[] columns);

        /// <summary>
        /// Regular Selects with objects in From clause
        /// </summary>
        /// <typeparam name="OfTable">Mapped class</typeparam>
        /// <param name="isDistinct">Apply DISTINCT statement</param>
        /// <param name="columns">Column names, function calls, variables, sub selects, etc...</param>
        /// <param name="configs">Mapped info of class OfTable</param>
        /// <param name="take">Amount to pick up in pagination</param>
        /// <param name="skip">Amount to skip up in pagination</param>
        /// <returns></returns>
        string CreateSelectFrom<OfTable>(
            bool isDistinct, 
            string[] columns, 
            TableConfigs<OfTable> configs, 
            uint? take = null, 
            uint? skip = null
        ) where OfTable : Entity;
    }
}
