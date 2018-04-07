using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;
using System;
using System.Collections.Generic;

namespace Domain.Entidade
{
    public class Processo : EntityCrud<Processo>
    {
        public string Numero { get; set; }
        public string RelatoFiscalizacao { get; set; }
        public DateTime Relato { get; set; }
        public string FiscalResponsavel { get; set; }
        public string FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public IEnumerable<Infracao> Infracao { get; set; }

        public override AbstractValidator<Processo> Validador => new ProcessoValidator();

        public override void PreencherDados(Processo data)
        {
            Numero = data.Numero;
            RelatoFiscalizacao = data.RelatoFiscalizacao;
            Relato = data.Relato;
            FiscalResponsavel = data.FiscalResponsavel;
            FornecedorId = data.FornecedorId;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class ProcessoValidator : AbstractValidator<Processo>
    {
        public ProcessoValidator()
        {
            RuleFor(x => x.RelatoFiscalizacao)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(1000);

            RuleFor(x => x.Relato)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);

            RuleFor(x => x.FiscalResponsavel)
               .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
               .MaximumLength(100);

            RuleFor(x => x.FornecedorId)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(36);

            RuleFor(x => x.Numero)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(30);

        }
    }
}
