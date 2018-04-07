using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Entidade
{
    public class Fornecedor : EntityCrud<Fornecedor>
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoMunicipal { get; set; }
        public decimal ReceitaBruta { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }

        public IEnumerable<Produto> Produto { get; set; }
        public IEnumerable<Processo> Processo { get; set; }

        public override AbstractValidator<Fornecedor> Validador => new FornecedorValidator();

        public override void PreencherDados(Fornecedor data)
        {
            Cnpj = data.Cnpj;
            RazaoSocial = data.RazaoSocial;
            InscricaoMunicipal = data.InscricaoMunicipal;
            ReceitaBruta = data.ReceitaBruta;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
        {
            RuleFor(x => x.Cnpj)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MinimumLength(14)
                .MaximumLength(14)
                .CNPJValido();

            RuleFor(x => x.RazaoSocial)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);

            RuleFor(x => x.InscricaoMunicipal)
                .MaximumLength(20);

            RuleFor(x => x.ReceitaBruta)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);
        }
    }
}
