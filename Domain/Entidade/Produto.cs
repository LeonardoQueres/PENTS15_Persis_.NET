using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;

namespace Domain.Entidade
{
    public class Produto : EntityCrud<Produto>
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Estoque { get; set; }
        public string FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public override AbstractValidator<Produto> Validador => new ProdutoValidator();

        public override void PreencherDados(Produto data)
        {
            Nome = data.Nome;
            Marca = data.Marca;
            Estoque = data.Estoque;
            FornecedorId = data.FornecedorId;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);

            RuleFor(x => x.Marca)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);

            RuleFor(x => x.Estoque)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);

            RuleFor(x => x.FornecedorId)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(36);

        }
    }
}
