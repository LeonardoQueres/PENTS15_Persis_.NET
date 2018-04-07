using Domain.Entidade;
using Shared.Interface.Repository;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IEnderecoRepository : IBaseRepository<Endereco, string>
    {
        void Remover(Endereco endereco);
        void RemoverPorId(string id);
        void RemoverTodos(string metadataId);
        void Inserir(Endereco endereco);
        void Atualizar(Endereco endereco);
        IEnumerable<Endereco> RecuperarTodos(string metadataId);
    }
}
