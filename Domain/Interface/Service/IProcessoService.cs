using Domain.DTO;
using Domain.Entidade;
using Shared.Interface.Service;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface IProcessoService : IBaseCrudService<Processo>
    {
        IEnumerable<ProcessoDTO> Listar();
        string GeraNumeroProcesso(string Cnpj);
    }
}
