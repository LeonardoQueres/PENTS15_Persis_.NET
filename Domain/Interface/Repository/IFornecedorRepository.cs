using Domain.DTO;
using Domain.Entidade;
using Shared.Interface.Repository;

namespace Domain.Interface.Repository
{
    public interface IFornecedorRepository : IBaseCrudRepository<Fornecedor>
    {
        FornecedorProcessoDTO RecuperarDadosFornecedor(string Id);
    }
}
