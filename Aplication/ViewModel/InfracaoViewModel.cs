using AutoMapper;
using Domain.DTO;
using Domain.Entidade;
using Shared.Tools;
using Shared.ViewModel;

namespace Aplication.ViewModel
{
    public class InfracaoViewModel : BaseViewModel
    {
        public string ProcessoId { get; set; }
        public int Gravidade { get; set; }
        public bool Atenuante { get; set; }
        public bool Agravante { get; set; }
        public string Multa { get; set; }


        #region Campos da Tela 
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string ReceitaBruta { get; set; }
        public string RelatoFiscalizacao { get; set; }
        public string Relato { get; set; }
        #endregion

        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<InfracaoViewModel, Infracao>()
                .ForMember(dest => dest.ProcessoId, opt => opt.MapFrom(orig => orig.ProcessoId))
                .ForMember(dest => dest.Gravidade, opt => opt.MapFrom(orig => orig.Gravidade))
                .ForMember(dest => dest.Atenuante, opt => opt.MapFrom(orig => orig.Atenuante))
                .ForMember(dest => dest.Agravante, opt => opt.MapFrom(orig => orig.Agravante))
                .ForMember(dest => dest.Multa, opt => opt.MapFrom(orig => orig.Multa));

            mapper.CreateMap<Infracao, InfracaoViewModel>()
                .ForMember(dest => dest.ProcessoId, opt => opt.MapFrom(orig => orig.ProcessoId))
                .ForMember(dest => dest.Gravidade, opt => opt.MapFrom(orig => orig.Gravidade))
                .ForMember(dest => dest.Atenuante, opt => opt.MapFrom(orig => orig.Atenuante))
                .ForMember(dest => dest.Agravante, opt => opt.MapFrom(orig => orig.Agravante))
                .ForMember(dest => dest.Multa, opt => opt.MapFrom(orig => orig.Multa.FormataValor()));
        }
    }

    public class InfracaoListaViewModel
    {
        public string Id { get; set; }
        public string ProcessoId { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Multa { get; set; }


        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<InfracaoDTO, InfracaoListaViewModel>()
               .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(orig => orig.Cnpj.FormatarCNPJ()))
               .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(orig => orig.RazaoSocial))
               .ForMember(dest => dest.Multa, opt => opt.MapFrom(orig => orig.Multa.FormataValor()));
        }
    }
}
