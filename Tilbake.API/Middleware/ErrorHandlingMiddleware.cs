using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tilbake.Application.Exceptions;

namespace Tilbake.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Regex UniqueConstraintRegex =
            new Regex("'UniqueError_([a-zA-Z0-9]*)_([a-zA-Z0-9]*)'", RegexOptions.Compiled);

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env).ConfigureAwait(true);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = String.Empty;

            var exceptionType = exception.GetType();
            //if (exception is DbUpdateException dbUpdateEx)
            //{
            //    message = exception.Message;
            //    if (dbUpdateEx.InnerException != null && dbUpdateEx.InnerException.InnerException != null)
            //    {
            //        if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
            //        {
            //            var valError = UniqueErrorFormatter(sqlException, dbUpdateEx.Entries);
            //            var returnMsg = valError.ErrorMessage;

            //            switch (sqlException.Number)
            //            {
            //                case 2627:  // Unique constraint error
            //                    break;
            //                case 547:   // Constraint check violation
            //                    break;
            //                case 2601:  // Duplicated key row error
            //                            // Constraint violation exception
            //                    message = returnMsg;
            //                    status = HttpStatusCode.InternalServerError;
            //                    // A custom exception of yours for concurrency issues
            //                    // throw new ConcurrencyException();
            //                    break;
            //                default:
            //                    // A custom exception of yours for other DB issues
            //                    //throw new DatabaseAccessException(
            //                    //  dbUpdateEx.Message, dbUpdateEx.InnerException);
            //                    break;
            //            }
            //        }
            //    }
            //    // throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
            //}
            //else

            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                if (env.IsEnvironment("Development"))
                    stackTrace = exception.StackTrace;
            }

            var result = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }

        public static ValidationResult UniqueErrorFormatter(SqlException ex, IReadOnlyList<EntityEntry> entitiesNotSaved)
        {
            var message = ex.Errors[0].Message;
            var matches = UniqueConstraintRegex.Matches(message);

            if (matches.Count == 0)
                return null;

            //currently the entitiesNotSaved is empty for unique constraints - see https://github.com/aspnet/EntityFrameworkCore/issues/7829
            var entityDisplayName = entitiesNotSaved.Count == 1
                ? entitiesNotSaved.Single().Entity.GetType().Name
                : matches[0].Groups[1].Value;

            var returnError = "Cannot have a duplicate " +
                              matches[0].Groups[2].Value + " in " +
                              entityDisplayName + ".";

            var openingBadValue = message.IndexOf("(");
            if (openingBadValue > 0)
            {
                var dupPart = message.Substring(openingBadValue + 1,
                    message.Length - openingBadValue - 3);
                returnError += $" Duplicate value was '{dupPart}'.";
            }

            return new ValidationResult(returnError, new[] { matches[0].Groups[2].Value });
        }
    }
}
