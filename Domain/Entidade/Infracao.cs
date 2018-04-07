using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;

namespace Domain.Entidade
{
    public class Infracao : EntityCrud<Infracao>
    {
        public string ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public int Gravidade { get; set; }
        public bool Atenuante { get; set; }
        public bool Agravante { get; set; }
        public decimal Multa { get; set; }

        public override AbstractValidator<Infracao> Validador => new InfracaoValidator();

        public override void PreencherDados(Infracao data)
        {
            ProcessoId = data.ProcessoId;
            Gravidade = data.Gravidade;
            Atenuante = data.Atenuante;
            Agravante = data.Agravante;
            Multa = data.Multa;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class InfracaoValidator : AbstractValidator<Infracao>
    {
        public InfracaoValidator()
        {
            RuleFor(x => x.ProcessoId)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);
            RuleFor(x => x.Gravidade)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);
            RuleFor(x => x.Atenuante)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);
            RuleFor(x => x.Agravante)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);
            RuleFor(x => x.Multa)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null);
        }
    }
}
