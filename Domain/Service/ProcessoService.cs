using Domain.DTO;
using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Service;
using Shared.Tools;
using System;
using System.Collections.Generic;

namespace Domain.Service
{
    public class ProcessoService : BaseCrudService<Processo>, IProcessoService
    {
        private readonly IProcessoRepository repository;
        private readonly IInfracaoRepository infracaoRepository;
        public ProcessoService(IProcessoRepository repository, IInfracaoRepository infracaoRepository) : base(repository)
        {
            this.repository = repository;
            this.infracaoRepository = infracaoRepository;
        }

        public string GeraNumeroProcesso(string Cnpj)
        {
            DateTime data = DateTime.Now;

            string dataFormatada = data.DataHoraFormatada("yyyyMMdd-HHmmss");

            return dataFormatada + "-" + Cnpj;
        }

        IEnumerable<ProcessoDTO> IProcessoService.Listar()
        {
            return repository.Listar();
        }

        public override void RemoverPorId(string id)
        {
            infracaoRepository.RemoverTodos(id);

            base.RemoverPorId(id);
        }
    }
}
