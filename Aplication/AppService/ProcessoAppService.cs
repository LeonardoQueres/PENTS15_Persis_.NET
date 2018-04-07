using Aplication.Interface;
using Aplication.ViewModel;
using AutoMapper;
using Domain.Entidade;
using Domain.Interface.Service;
using Shared.AppService;
using Shared.Interface;
using Shared.Interface.Validator;
using Shared.Tools;
using System.Collections.Generic;

namespace Aplication.AppService
{
    public class ProcessoAppService : BaseCrudAppService<ProcessoViewModel, Processo>, IProcessoAppService
    {
        private readonly IProcessoService service;
        private readonly IInfracaoService infracaoService;
        private readonly IMapper mapper;
        public ProcessoAppService(IProcessoService service,
                                  IInfracaoService infracaoService,
                                IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.infracaoService = infracaoService;
            this.mapper = mapper;
        }

        public override IResultadoApplication Inserir(ProcessoViewModel viewModel)
        {
            viewModel.Numero = service.GeraNumeroProcesso(viewModel.Cnpj.RemoverCaracteres());

            return base.Inserir(viewModel);
        }

        IResultadoApplication<ICollection<ProcessoListaViewModel>> IProcessoAppService.Listar()
        {
            var result = new ResultadoApplication<ICollection<ProcessoListaViewModel>>();

            try
            {
                result.DefinirData(mapper.Map<ICollection<ProcessoListaViewModel>>(service.Listar()));
                result.ExecutadoComSuccesso();
            }
            catch (System.Exception ex)
            {
                result.ExecutadoComErro(ex);
            }

            return result;
        }
    }
}
