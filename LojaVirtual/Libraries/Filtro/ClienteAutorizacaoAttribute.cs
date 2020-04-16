using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Libraries.Filtro
{
    /*
     * Tipos de Filtros:
     * Autorização: IAuthorizationFilter
     * Recurso: IResourceFilter
     * Ação: IActionFilter
     * Exceção: IExceptionFilter
     * Resultado: IResultFilter
     */

    //Attribute: Herança para poder usar essa classe como um atributo na minha controller [ClienteAutorizacao]

    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginCliente _loginCliente;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            /*
             * Como se trata de um atributo, não consigo utilizar a injeção de dependência através do construtor, pois na hora de chamar o atributo
             * irá pedir os parâmetros. Neste caso, vou utilizar o context da própria classe para chamar o serviço
             */

            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Cliente cliente = _loginCliente.GetCliente();

            if (cliente == null)
            {
                context.Result =  new ContentResult() { Content = "Acesso negado." };
            }
        }
    }
}
