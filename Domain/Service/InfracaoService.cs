using Domain.DTO;
using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Service;
using System.Collections.Generic;

namespace Domain.Service
{
    public class InfracaoService : BaseCrudService<Infracao>, IInfracaoService
    {
        private readonly IInfracaoRepository repository;
        public InfracaoService(IInfracaoRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public string CalculaMulta(decimal rb, int g, bool ag, bool at)
        {
            //M =        PB + [(RB – R$120.000,00)*0,10) + R$120.000,00]*[UFIR*(Ag+At)*G]
            var agravante = ag ? 1M : 0M;
            var atenuante = at ? 0.33M : 1M;

            var multa = 500 + (((rb - 120000) * 0.10M) + 120000) * (3 * (agravante + atenuante) * g);

            return multa.ToString();
        }

        IEnumerable<InfracaoDTO> IInfracaoService.Listar(string Id)
        {
            return repository.Listar(Id);
        }

        void IInfracaoService.RemoverTodos(string ProcessoId)
        {
            repository.RemoverTodos(ProcessoId);
        }
    }
}
