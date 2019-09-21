using System;
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
    [RoutePrefix("area-administrativa/categorias")]
    public class CategoriasController : BaseController
    {

        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_categoriaAppService.ObterTodos());
        }

        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var categoriaViewModel = _categoriaAppService.ObterPorId(id);
            
            if (categoriaViewModel == null) return HttpNotFound();

            return View(categoriaViewModel);
        }

        [Route("cadastrar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);

            _categoriaAppService.Adicionar(categoriaViewModel);
         
            return RedirectToAction("Index");
        }

        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {

            var categoriaViewModel = _categoriaAppService.ObterPorId(id);

            if (categoriaViewModel == null) return HttpNotFound();

            return View(categoriaViewModel);
        }

        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoriaViewModel)
        {
            if (! ModelState.IsValid) return View(categoriaViewModel);

            _categoriaAppService.Atualizar(categoriaViewModel);

            return RedirectToAction("Index");  
        }

        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var categoriaViewModel = _categoriaAppService.ObterPorId(id);

            if (categoriaViewModel == null) return HttpNotFound();

            return View(categoriaViewModel);
        }

        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var categoriaViewModel = _categoriaAppService.Remover(id);

            if (categoriaViewModel.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(categoriaViewModel.ValidationResult);
            return View(categoriaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _categoriaAppService.Dispose();
        }
    }
}
