using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace Agenda.Web.Filters
{
    public class LogAttribute : FilterAttribute, IActionFilter, IResultFilter, IExceptionFilter
    {
        #region Log
        private void Log(string message, [CallerMemberName] string methodName = null)
        {
            Trace.WriteLine($"{DateTime.Now} - [{methodName}] - {message}");
        }
        #endregion

        #region IActionFilter
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log($"Iniciando execução do action '{filterContext.ActionDescriptor.ActionName}' da controller '{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}'...");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log($"Execução do action '{filterContext.ActionDescriptor.ActionName}' da controller '{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}' finalizada!");
        }
        #endregion

        #region IResultFilter
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log($"Iniciando processamento do resultado de tipo '{filterContext.Result.GetType().Name}'...");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log($"Processamento do resultado de tipo '{filterContext.Result.GetType().Name}' finalizada!");
        }
        #endregion

        #region IExceptionFilter
        public void OnException(ExceptionContext filterContext)
        {
            Log($"Ocorreu uma exceção do tipo '{filterContext.Exception.GetType().Name}': '{filterContext.Exception.Message}'!");
        }
        #endregion
    }
}