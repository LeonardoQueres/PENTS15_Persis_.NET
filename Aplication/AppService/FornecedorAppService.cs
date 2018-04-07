using Aplication.Interface;
using Aplication.ViewModel;
using AutoMapper;
using Domain.Entidade;
using Domain.Interface.Service;
using Shared.AppService;
using Shared.Interface;
using Shared.Interface.Validator;

namespace Aplication.AppService
{
    public class FornecedorAppService : BaseCrudAppService<FornecedorViewModel, Fornecedor>, IFornecedorAppService
    {
        private readonly IFornecedorService service;
        private readonly IEnderecoService enderecoService;
        private readonly IMapper mapper;
        public FornecedorAppService(IFornecedorService service,
                                    IEnderecoService enderecoService,
                                IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.enderecoService = enderecoService;
            this.mapper = mapper;
        }

        IResultadoApplication<FornecedorListaViewModel> IFornecedorAppService.RecuperarDadosFornecedor(string Id)
        {
            var result = new ResultadoApplication<FornecedorListaViewModel>();

            try
            {
                result.DefinirData(mapper.Map<FornecedorListaViewModel>(service.RecuperarDadosFornecedor(Id)));
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
