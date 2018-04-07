using Domain.DTO;
using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Service;
using Shared.Validator;

namespace Domain.Service
{
    public class FornecedorService : BaseCrudService<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository repository;

        private readonly IEnderecoService enderecoService;


        public FornecedorService(IFornecedorRepository repository,
                                IEnderecoService enderecoService
                                            ) : base(repository)
        {
            this.repository = repository;
            this.enderecoService = enderecoService;
        }


        public override ResultadoValidacao Inserir(Fornecedor model)
        {
            var resultado = base.Inserir(model);

            if (resultado.IsValid)
            {
                resultado.AdicionarMensagens(enderecoService.Processar(model.Enderecos, null, model.Id));
            }
            return resultado;
        }

        public override ResultadoValidacao Atualizar(Fornecedor model)
        {
            var fornecedor = this.RecuperarPorId(model.Id);
            fornecedor.PreencherDados(model);

            var resultado = base.Atualizar(model);

            if (resultado.IsValid)
            {
                resultado.AdicionarMensagens(enderecoService.Processar(model.Enderecos, fornecedor.Enderecos, model.Id));
            }
            return resultado;
        }

        public override Fornecedor RecuperarPorId(string id)
        {
            var fornecedor = base.RecuperarPorId(id);

            fornecedor.Enderecos = enderecoService.RecuperarTodos(id);

            return fornecedor;
        }

        public override void RemoverPorId(string id)
        {
            enderecoService.RemoverTodos(id);

            base.RemoverPorId(id);
        }

        FornecedorProcessoDTO IFornecedorService.RecuperarDadosFornecedor(string Id)
        {
            return repository.RecuperarDadosFornecedor(Id);
        }
    }
}
