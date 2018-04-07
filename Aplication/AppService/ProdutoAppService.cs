using Aplication.Interface;
using Aplication.ViewModel;
using AutoMapper;
using Domain.Entidade;
using Domain.Interface.Service;
using Shared.Interface;

namespace Aplication.AppService
{
    public class ProdutoAppService : BaseCrudAppService<ProdutoViewModel, Produto>, IProdutoAppService
    {
        private readonly IProdutoService service;
        private readonly IMapper mapper;
        public ProdutoAppService(IProdutoService service,
                                IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
