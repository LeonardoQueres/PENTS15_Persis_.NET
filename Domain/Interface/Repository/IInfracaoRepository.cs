using Domain.DTO;
using Domain.Entidade;
using Shared.Interface.Repository;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IInfracaoRepository : IBaseCrudRepository<Infracao>
    {
        IEnumerable<InfracaoDTO> Listar(string Id);
        void RemoverTodos(string ProcessoId);
    }
}
