using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppVendas.Application.Intefaces;
using AppVendas.Application.Services;
using AppVendas.Application.ViewModels;
using AppVendas.Infra.CrossCutting.Filters;
using AppVendas.Ui.Models;
using DomainValidation.Validation;

namespace AppVendas.Ui.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/produtos")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService;

        public ProdutosController(IProdutoAppService produtoAppService, ICategoriaAppService categoriaAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;

            IEnumerable<CategoriaViewModel> categorias = _categoriaAppService.ObterTodos().ToList();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
        }

        // [ClaimsAuthorize("Produtos","LISTAR")]
        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_produtoAppService.ObterTodos());
        }

        //  [ClaimsAuthorize("Produtos", "DETALHES")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var produtoCategoriaViewModel = _produtoAppService.ObterPorId(id);

            if (produtoCategoriaViewModel == null) return HttpNotFound();

            return View(produtoCategoriaViewModel);
        }

        //  [ClaimsAuthorize("Produtos", "INCLUIR")]
        [Route("cadastrar")]
        public ActionResult Create()
        {
           
            return View();
        }

        //  [ClaimsAuthorize("Produtos", "INCLUIR")]
        [Route("cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {

            if (!ModelState.IsValid) return View(produtoViewModel);

            produtoViewModel = _produtoAppService.Adicionar(produtoViewModel);

            if (produtoViewModel.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(produtoViewModel.ValidationResult);
            return View(produtoViewModel);
        }



        // [ClaimsAuthorize("Produtos", "EDITAR")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var produtoCategoriaViewModel = _produtoAppService.ObterPorId(id);

            if (produtoCategoriaViewModel == null) return HttpNotFound();

            return View(produtoCategoriaViewModel);
        }

        // [ClaimsAuthorize("Produtos", "EDITAR")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            produtoViewModel = _produtoAppService.Atualizar(produtoViewModel);

            if (produtoViewModel.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(produtoViewModel.ValidationResult);
            return View(produtoViewModel);
        }

        // [ClaimsAuthorize("Produtos", "EXCLUIR")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var produtoViewModel = _produtoAppService.ObterPorId(id);

            if (produtoViewModel == null) return HttpNotFound();

            return View(produtoViewModel);
        }

        // [ClaimsAuthorize("Produtos", "EXCLUIR")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _produtoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _produtoAppService.Dispose();
        }
    }
}
