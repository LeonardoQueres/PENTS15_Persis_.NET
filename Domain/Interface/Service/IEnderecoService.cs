using Domain.Entidade;
using Shared.Interface.Service;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface IEnderecoService : IBaseService<Endereco, string>
    {
        ResultadoValidacao Processar(Endereco enderecoModel, Endereco enderecoBancoDados, string metadataId);

        ResultadoValidacao Processar(IEnumerable<Endereco> enderecosModel, IEnumerable<Endereco> enderecosBancoDados, string metadataId);

        IEnumerable<Endereco> RecuperarTodos(string metadataId);

        void RemoverPorId(string id);

        void RemoverTodos(string metadataId);


    }
}
