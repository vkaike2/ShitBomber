using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shitbomber.jogo.domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace shitbomber.jogo.api.ExceptionFilter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {

            PadraoResponse<string> responseData = new PadraoResponse<string>()
            {
                Mensagem = context.Exception.Message
            };
            HttpStatusCode status = HttpStatusCode.BadRequest;

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(responseData);
        }
    }
}
