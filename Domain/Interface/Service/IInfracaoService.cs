using Domain.DTO;
using Domain.Entidade;
using Shared.Interface.Service;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface IInfracaoService : IBaseCrudService<Infracao>
    {
        string CalculaMulta(decimal rb, int g, bool ag, bool at);
        IEnumerable<InfracaoDTO> Listar(string Id);
        void RemoverTodos(string ProcessoId);
    }
}
