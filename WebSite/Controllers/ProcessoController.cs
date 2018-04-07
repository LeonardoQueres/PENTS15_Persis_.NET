using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebSite.Controllers
{
    public class ProcessoController : Controller
    {
        private readonly IProcessoAppService appService;
        private readonly IFornecedorAppService fornecedorAppService;

        public ProcessoController(IProcessoAppService appService, IFornecedorAppService fornecedorAppService)
        {
            this.appService = appService;
            this.fornecedorAppService = fornecedorAppService;
        }

        public IActionResult Index()
        {
            var resultado = appService.Listar().Data;

            return View(resultado);
        }

        public virtual IActionResult Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);

            var viewModel = resultado.Data;
            viewModel.SomenteLeitura = true;

            PreencheFornecedor(viewModel);
            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Cadastrar()
        {
            var viewModel = new ProcessoViewModel();

            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);

            var viewModel = resultado.Data;

            PreencheFornecedor(viewModel);
            PreencheCombosTela(viewModel);

            ViewBag.desabilitaCampo = true;

            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(ProcessoViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public IActionResult Editar(ProcessoViewModel viewModel)
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

        private void PreencheCombosTela(ProcessoViewModel model)
        {
            model.Fornecedores = fornecedorAppService.RecuperarDropdown().Data;
        }

        private void PreencheFornecedor(ProcessoViewModel model)
        {
            var fornecedor = fornecedorAppService.RecuperarPorId(model.FornecedorId).Data;

            model.Cnpj = fornecedor.Cnpj;
            model.InscricaoMunicipal = fornecedor.InscricaoMunicipal;
            model.RazaoSocial = fornecedor.RazaoSocial;
        }


        public JsonResult ListagemFornecedorJson(string Id)
        {
            var fornecedor = fornecedorAppService.RecuperarPorId(Id).Data;
            var settings = new JsonSerializerSettings();
            return Json(fornecedor, settings);
        }
    }
}