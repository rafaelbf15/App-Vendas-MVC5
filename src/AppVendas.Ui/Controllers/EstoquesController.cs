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
using AppVendas.Ui.Models;

namespace AppVendas.Ui.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/estoque")]
    public class EstoquesController : BaseController
    {
        private readonly IEstoqueAppService _estoqueAppService;
        private readonly IProdutoAppService _produtoAppService;

        public EstoquesController(IEstoqueAppService estoqueAppService, IProdutoAppService produtoAppService)
        {
            _estoqueAppService = estoqueAppService;
            _produtoAppService = produtoAppService;

            IEnumerable<ProdutoViewModel> produtos = _produtoAppService.ObterTodos().ToList();
            ViewBag.Produtos = new SelectList(produtos, "Id", "Nome");
        }

        // [ClaimsAuthorize("Estoque","LISTAR")]
        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_estoqueAppService.ObterTodos());
        }

        //  [ClaimsAuthorize("Estoque", "DETALHES")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var estoqueViewModel = _estoqueAppService.ObterPorId(id);

            if (estoqueViewModel == null) return HttpNotFound();

            return View(estoqueViewModel);
        }

        //  [ClaimsAuthorize("Estoque", "INCLUIR")]
        [Route("cadastrar")]
        public ActionResult Create()
        {
            return View();
        }

        //  [ClaimsAuthorize("Estoque", "INCLUIR")]
        [Route("cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstoqueViewModel estoqueViewModel)
        {
            if (!ModelState.IsValid) return View(estoqueViewModel);

            estoqueViewModel = _estoqueAppService.Adicionar(estoqueViewModel);

            return RedirectToAction("Index");
        }

        // [ClaimsAuthorize("Estoque", "EDITAR")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var estoqueViewModel = _estoqueAppService.ObterPorId(id);

            if (estoqueViewModel == null) return HttpNotFound();

            return View(estoqueViewModel);
        }

        // [ClaimsAuthorize("Estoque", "EDITAR")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstoqueViewModel estoqueViewModel)
        {
            if (!ModelState.IsValid) return View(estoqueViewModel);

            estoqueViewModel = _estoqueAppService.Atualizar(estoqueViewModel);

            return RedirectToAction("Index");
        }

        // [ClaimsAuthorize("Estoque", "EXCLUIR")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var estoqueViewModel = _estoqueAppService.ObterPorId(id);

            if (estoqueViewModel == null) return HttpNotFound();

            return View(estoqueViewModel);
        }

        // [ClaimsAuthorize("Estoque", "EXCLUIR")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _estoqueAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _estoqueAppService.Dispose();
        }
    }
}
