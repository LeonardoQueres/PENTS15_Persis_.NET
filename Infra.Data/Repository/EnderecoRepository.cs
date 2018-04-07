using Domain.Entidade;
using Domain.Interface.Repository;
using Shared.Infra;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco, string>, IEnderecoRepository
    {
        private readonly AdminContext dbContext;

        public EnderecoRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        void IEnderecoRepository.Remover(Endereco endereco)
        {
            base.Remover(endereco);
        }

        void IEnderecoRepository.RemoverPorId(string id)
        {
            base.Remover(base.RecuperarPorId(id));
        }

        void IEnderecoRepository.RemoverTodos(string metadataId)
        {
            dbContext.Set<Endereco>()
                .Where(x => x.MetadataId == metadataId)
                .ToList()
                .ForEach(x => base.Remover(x));
        }

        void IEnderecoRepository.Inserir(Endereco endereco)
        {
            base.Inserir(endereco);
        }

        void IEnderecoRepository.Atualizar(Endereco endereco)
        {
            base.Atualizar(endereco);
        }

        IEnumerable<Endereco> IEnderecoRepository.RecuperarTodos(string metadataId)
        {
            return dbContext.Set<Endereco>()
                .Where(x => x.MetadataId == metadataId)
                .ToList();
        }
    }
}
