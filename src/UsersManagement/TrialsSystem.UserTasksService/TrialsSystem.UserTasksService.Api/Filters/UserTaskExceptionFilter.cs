using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.Exceptions;

namespace TrialsSystem.UserTasksService.Api.Filters
{
    public class UserTaskExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<UserTaskExceptionFilter> _logger;

        public UserTaskExceptionFilter(ILogger<UserTaskExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled) return;

            switch (context.Exception)
            {
                case UserTasksNotFoundDomainException userTasksNotFoundDomainException:
                    _logger.LogError("User task {taskName} was not found.",
                        userTasksNotFoundDomainException.Name);
                    SetContextResult(context, new NotFoundObjectResult($"User task {userTasksNotFoundDomainException.Name} was not found."));
                    break;
                case UserTasksDomainException userTasksDomainException:
                    _logger.LogError("Domain exception occured. Task name: {taskName}");
                    SetContextResult(context, new BadRequestResult());
                    break;
                default:
                    _logger.LogError("System error occurred. Message: {message}. Inner exception: {innerException}.",
                        context.Exception.Message,
                        context.Exception.InnerException?.Message,
                        context.Exception.StackTrace);
                    SetContextResult(context, new StatusCodeResult(StatusCodes.Status500InternalServerError));
                    break;
            }
        }

        private void SetContextResult(ExceptionContext context, IActionResult result)
        {
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }

}
