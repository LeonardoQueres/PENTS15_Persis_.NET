using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService appService;
        private readonly IFornecedorAppService fornecedorAppService;

        public ProdutoController(IProdutoAppService appService, IFornecedorAppService fornecedorAppService)
        {
            this.appService = appService;
            this.fornecedorAppService = fornecedorAppService;
        }
        public IActionResult Index()
        {
            var resultado = appService.RecuperarTodos().Data;

            return View(resultado);
        }

        public virtual IActionResult Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);

            var model = resultado.Data;
            model.SomenteLeitura = true;

            PreencheCombosTela(model);

            return View("Form", model);
        }

        public IActionResult Cadastrar()
        {
            var viewModel = new ProdutoViewModel();

            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);

            var viewModel = resultado.Data;

            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public IActionResult Editar(ProdutoViewModel viewModel)
        {
            var resultado = appService.Atualizar(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public virtual IActionResult Excluir(string id)
        {
            var resultado = appService.RemoverPorId(id);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        private void PreencheCombosTela(ProdutoViewModel model)
        {
            model.Fornecedores = fornecedorAppService.RecuperarDropdown().Data;
        }
    }
}