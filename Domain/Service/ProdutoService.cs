using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Service;

namespace Domain.Service
{
    public class ProdutoService : BaseCrudService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository repository;

        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
