using Domain.DTO;
using Domain.Entidade;
using Shared.Interface.Repository;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IProcessoRepository : IBaseCrudRepository<Processo>
    {
        IEnumerable<ProcessoDTO> Listar();
    }
}
