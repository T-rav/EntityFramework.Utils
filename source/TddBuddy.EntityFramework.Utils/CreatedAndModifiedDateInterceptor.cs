using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using TddBuddy.EntityFramework.Utils.DateTimeProvider;

namespace TddBuddy.EntityFramework.Utils
{
    public class CreatedAndModifiedDateInterceptor : IDbCommandTreeInterceptor
    {
        public const string CreatedColumnName = "Created";
        public const string ModifiedColumnName = "Modified";

        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace != DataSpace.SSpace)
            {
                return;
            }

            var provideDateTime = interceptionContext.DbContexts.OfType<IDateTimeProvider>().FirstOrDefault();
            var dateTime = provideDateTime?.DateTimeNow ?? DateTime.Now;

            var insertCommand = interceptionContext.Result as DbInsertCommandTree;
            if (insertCommand != null)
            {
                interceptionContext.Result = HandleInsertCommand(insertCommand, dateTime);
            }

            var updateCommand = interceptionContext.OriginalResult as DbUpdateCommandTree;
            if (updateCommand != null)
            {
                interceptionContext.Result = HandleUpdateCommand(updateCommand, dateTime);
            }
        }

        private static DbCommandTree HandleInsertCommand(DbInsertCommandTree insertCommand, DateTime dateTime)
        {
            var setClauses = insertCommand.SetClauses
                .Select(clause => clause.UpdateIfMatch(CreatedColumnName, DbExpression.FromDateTime(dateTime)))
                .Select(clause => clause.UpdateIfMatch(ModifiedColumnName, DbExpression.FromDateTime(dateTime)))
                .ToList();

            return new DbInsertCommandTree(
                insertCommand.MetadataWorkspace,
                insertCommand.DataSpace,
                insertCommand.Target,
                setClauses.AsReadOnly(),
                insertCommand.Returning);
        }

        private static DbCommandTree HandleUpdateCommand(DbUpdateCommandTree updateCommand, DateTime dateTime)
        {
            var setClauses = updateCommand.SetClauses
                .Where(clause => !clause.IsFor(CreatedColumnName))
                .Select(clause => clause.UpdateIfMatch(ModifiedColumnName, DbExpression.FromDateTime(dateTime)))
                .ToList();

            return new DbUpdateCommandTree(
                updateCommand.MetadataWorkspace,
                updateCommand.DataSpace,
                updateCommand.Target,
                updateCommand.Predicate,
                setClauses.AsReadOnly(), null);
        }
    }
}