using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppVendas.Application.Intefaces;
using AppVendas.Application.ViewModels;
using AppVendas.Ui.Models;

namespace AppVendas.Ui.Controllers
{

    [RoutePrefix("loja")]
    public class VendasController : BaseController
    {
        private readonly IVendaAppService _vendaAppService;
        private readonly IEstoqueAppService _estoqueAppService;

        public VendasController(IVendaAppService vendaAppService, IEstoqueAppService estoqueAppService )
        {
            _vendaAppService = vendaAppService;
            _estoqueAppService = estoqueAppService;

            IEnumerable<EstoqueViewModel> estoque = _estoqueAppService.ObterTodos().ToList();
            ViewBag.Estoque = new SelectList(estoque, "ProdutoId", "Produto.Nome");
        }

        [Route("")]
        [Route("listar-produtos-estoque")]
        public ActionResult Index()
        {
            
            return View(_estoqueAppService.ObterTodos());
        }

        [Route("listar-todos")]
        public ActionResult Compra()
        {

            return View(_vendaAppService.ObterTodos());
        }



        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var estoqueViewModel = _estoqueAppService.ObterPorId(id);

            if (estoqueViewModel == null) return HttpNotFound();

            return View(estoqueViewModel);
        }

        [Route("cadastrar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid) return View(vendaViewModel);

            vendaViewModel = _vendaAppService.Adicionar(vendaViewModel);

            if (vendaViewModel.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(vendaViewModel.ValidationResult);
            return View(vendaViewModel);
        }
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var vendaViewModel = _vendaAppService.ObterPorId(id);

            if (vendaViewModel == null) return HttpNotFound();

            return View(vendaViewModel);
        }

        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid) return View(vendaViewModel);

            vendaViewModel = _vendaAppService.Atualizar(vendaViewModel);

            if (vendaViewModel.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(vendaViewModel.ValidationResult);
            return View(vendaViewModel);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vendaViewModel = _vendaAppService.ObterPorId(id);

            if (vendaViewModel == null) return HttpNotFound();

            return View(vendaViewModel);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _vendaAppService.Remover(id);
            return RedirectToAction("Compra");
        }

        protected override void Dispose(bool disposing)
        {
            _vendaAppService.Dispose();
        }
    }
}
