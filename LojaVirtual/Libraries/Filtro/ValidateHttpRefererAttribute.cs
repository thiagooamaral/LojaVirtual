using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Libraries.Filtro
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        //Atributo utilizado para verificar de onde esta vindo a requisição, se é do mesmo domínio do nosso site.
        //Caso seja domínio diferente, não aceita
        //Utilizado para evitar ataques CSRF

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Executado antes de passar pelo controlador
            string referer = context.HttpContext.Request.Headers["Referer"];

            if (String.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Acesso negado!" };
            }
            else
            {
                Uri uri = new Uri(referer);

                string hostReferer = uri.Host;
                string hostServidor = context.HttpContext.Request.Host.Host;

                if (hostReferer != hostServidor)
                {
                    context.Result = new ContentResult() { Content = "Acesso negado!" };
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Executado após passar pelo controlador
        }
    }
}
