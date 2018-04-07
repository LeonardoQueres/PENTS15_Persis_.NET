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
    public class InfracaoAppService : BaseCrudAppService<InfracaoViewModel, Infracao>, IInfracaoAppService
    {
        private readonly IInfracaoService service;
        private readonly IMapper mapper;
        public InfracaoAppService(IInfracaoService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public override IResultadoApplication Inserir(InfracaoViewModel viewModel)
        {
            var ReceitaBruta = viewModel.ReceitaBruta.ToDecimal();

            viewModel.Multa = service.CalculaMulta(ReceitaBruta, viewModel.Gravidade, viewModel.Agravante, viewModel.Atenuante);

            return base.Inserir(viewModel);
        }

        public override IResultadoApplication Atualizar(InfracaoViewModel viewModel)
        {
            var ReceitaBruta = viewModel.ReceitaBruta.ToDecimal();

            viewModel.Multa = service.CalculaMulta(ReceitaBruta, viewModel.Gravidade, viewModel.Agravante, viewModel.Atenuante);

            return base.Atualizar(viewModel);
        }


        IResultadoApplication<ICollection<InfracaoListaViewModel>> IInfracaoAppService.Listar(string Id)
        {
            var result = new ResultadoApplication<ICollection<InfracaoListaViewModel>>();

            try
            {
                result.DefinirData(mapper.Map<ICollection<InfracaoListaViewModel>>(service.Listar(Id)));
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
