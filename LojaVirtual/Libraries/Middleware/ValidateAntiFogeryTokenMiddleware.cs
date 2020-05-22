using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Middleware
{
    public class ValidateAntiFogeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;

        //Middleware para realizar as validações de token vindo dos formulários
        //Ao invés de colocar um annotation em cima de cada método, é validado tudo por aqui

        public ValidateAntiFogeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            //Quando se trata de uma requisição AJAX, o cabeçalho x-request-with vem com a propriedade XMLHttpRequest
            var Cabecalho = context.Request.Headers["x-requested-with"];
            bool AJAX = (Cabecalho == "XMLHttpRequest") ? true : false;

            if (HttpMethods.IsPost(context.Request.Method) && !(context.Request.Form.Files.Count == 1 && AJAX))
            {
                await _antiforgery.ValidateRequestAsync(context);
            }

            await _next(context);
        }
    }
}
