﻿using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    //[ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index(int? pagina)
        {
            var categorias = _categoriaRepository.ObterTodasCategorias(pagina);
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Categoria categoria)
        {
            //TODO: Implementar
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Categoria categoria)
        {
            //TODO: Implementar
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            return View();
        }
    }
}