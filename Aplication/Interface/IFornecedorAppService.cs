using Aplication.ViewModel;
using Domain.Entidade;
using Shared.Interface.AppService;
using Shared.Interface.Validator;

namespace Aplication.Interface
{
    public interface IFornecedorAppService : IBaseCrudAppService<FornecedorViewModel, Fornecedor>
    {
        IResultadoApplication<FornecedorListaViewModel> RecuperarDadosFornecedor(string Id);
    }
}
