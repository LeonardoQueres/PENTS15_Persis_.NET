using Aplication.Interface;
using Aplication.ViewModel;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Shared.Tools;

namespace WebSite.Controllers
{
    public class FornecedorController : Controller
    {

        private readonly IFornecedorAppService appService;

        public FornecedorController(IFornecedorAppService appService)
        {
            this.appService = appService;
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
            var viewModel = new FornecedorViewModel()
            {
                TelaEnderecos = new EnderecoTelaViewModel()
                {
                    ApenasUmEndereco = false
                }
            };

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
        public IActionResult Cadastrar(FornecedorViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public IActionResult Editar(FornecedorViewModel viewModel)
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

        private void PreencheCombosTela(FornecedorViewModel model)
        {
            model.Ufs = EnumExtensions.ToDictionary<UfEnum>();
            model.TelaEnderecos.Ufs = model.Ufs;
        }
    }
}