using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Tools;

namespace WebSite.Controllers
{
    public class InfracaoController : Controller
    {
        private readonly IInfracaoAppService appService;
        private readonly IFornecedorAppService fornecedorAppService;
        public InfracaoController(IInfracaoAppService appService, IFornecedorAppService fornecedorAppService)
        {
            this.appService = appService;
            this.fornecedorAppService = fornecedorAppService;
        }

        public IActionResult Index(string IdProc)
        {
            var resultado = appService.Listar(IdProc).Data;
            ViewBag.IdProcesso = IdProc;
            return View(resultado);
        }

        public virtual IActionResult Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);

            var viewModel = resultado.Data;
            viewModel.SomenteLeitura = true;
            PreencheFornecedor(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Cadastrar(string IdProc)
        {
            var viewModel = new InfracaoViewModel();
            viewModel.ProcessoId = IdProc;
            PreencheFornecedor(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);

            var viewModel = resultado.Data;
            PreencheFornecedor(viewModel);

            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(InfracaoViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action("Index", "Infracao", new { IdProc = viewModel.ProcessoId }));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public IActionResult Editar(InfracaoViewModel viewModel)
        {
            var resultado = appService.Atualizar(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action("Index", "Infracao", new { IdProc = viewModel.ProcessoId }));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public virtual IActionResult Excluir(string IdProcess, string id)
        {
            var resultado = appService.RemoverPorId(id);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action("Index", "Infracao", new { IdProc = IdProcess }));

            return Json(resultado.Retorno());
        }

        private void PreencheFornecedor(InfracaoViewModel viewModel)
        {
            var fornecedor = fornecedorAppService.RecuperarDadosFornecedor(viewModel.ProcessoId).Data;

            viewModel.Cnpj = fornecedor.Cnpj;
            viewModel.RazaoSocial = fornecedor.RazaoSocial;
            viewModel.ReceitaBruta = fornecedor.ReceitaBruta;
            viewModel.Relato = fornecedor.Relato.DataFormatada();
            viewModel.RelatoFiscalizacao = fornecedor.RelatoFiscalizacao;
        }
    }
}