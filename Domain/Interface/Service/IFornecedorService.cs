using Domain.DTO;
using Domain.Entidade;
using Shared.Interface.Service;

namespace Domain.Interface.Service
{
    public interface IFornecedorService : IBaseCrudService<Fornecedor>
    {
        FornecedorProcessoDTO RecuperarDadosFornecedor(string Id);
    }
}
