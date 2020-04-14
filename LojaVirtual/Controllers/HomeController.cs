using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _repositoryCliente;
        private INewsletterRepository _repositoryNewsletter;

        public HomeController(IClienteRepository repositoryCliente, INewsletterRepository repositoryNewsletter)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryNewsletter = repositoryNewsletter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            //Essa é uma forma mais simples de receber os dados do formulário

            if (ModelState.IsValid)
            {
                _repositoryNewsletter.Cadastrar(newsletter);

                //Neste caso, estou utilizando o método TempData pois estou redirecionando a página. Senão, poderia utilizar o View ou ViewBag
                //O TempData armazena as informações até elas serem utilizadas, depois disso as apaga! Para mante-lás, utilize TempData.Keep
                TempData["MSG_S"] = "E-mail cadastrado! Agora você vai receber promoções especiais no seu e-mail! Fique atento as novidades!";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato
                {
                    Nome = HttpContext.Request.Form["nome"],
                    Email = HttpContext.Request.Form["email"],
                    Texto = HttpContext.Request.Form["texto"]
                };

                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listaMensagens)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }
            }
            catch (Exception ex)
            {
                ViewData["MSG_E"] = "Opps! Tivemos um erro, tente novamente mais tarde!";

                //TODO: Implementar Log
            }

            return View("Contato");
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositoryCliente.Cadastrar(cliente);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";

                //TODO: Implementar redicionamento diferentes (Painel, Carrinhode compras, etc)

                return RedirectToAction(nameof(CadastroCliente));
            }

            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}