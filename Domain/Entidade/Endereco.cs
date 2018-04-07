using Domain.Enum;
using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;

namespace Domain.Entidade
{
    public class Endereco : EntityCrud<Endereco>
    {
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        public string Bairro { get; set; }

        public string Municipio { get; set; }

        public UfEnum? Uf { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }
        public string MetadataId { get; set; }

        public override AbstractValidator<Endereco> Validador => new EnderecoValidator();

        public override void PreencherDados(Endereco data)
        {
            Logradouro = data.Logradouro;
            Numero = data.Numero;
            Bairro = data.Bairro;
            Municipio = data.Municipio;
            Uf = data.Uf;
            Cep = data.Cep;
            Complemento = data.Complemento;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }
    internal class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.MetadataId)
                   .NotNull();

            RuleFor(x => x.Logradouro)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);

            RuleFor(x => x.Numero)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);

            RuleFor(x => x.Bairro)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);

            RuleFor(x => x.Municipio)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(200);


            RuleFor(x => x.Uf)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);

            RuleFor(x => x.Cep)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MinimumLength(9)
                .MaximumLength(9);

            RuleFor(x => x.Complemento)
                .MaximumLength(50);
        }
    }
}
