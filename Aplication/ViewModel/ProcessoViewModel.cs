using AutoMapper;
using Domain.DTO;
using Domain.Entidade;
using Shared.Tools;
using Shared.ViewModel;
using System.Collections.Generic;

namespace Aplication.ViewModel
{
    public class ProcessoViewModel : BaseViewModel
    {
        public string Numero { get; set; }
        public string RelatoFiscalizacao { get; set; }
        public string Relato { get; set; }
        public string FiscalResponsavel { get; set; }
        public string FornecedorId { get; set; }

        #region Campos da Tela 
        public IDictionary<string, string> Fornecedores { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoMunicipal { get; set; }

        #endregion

        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<ProcessoViewModel, Processo>()
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(orig => orig.Numero))
                .ForMember(dest => dest.RelatoFiscalizacao, opt => opt.MapFrom(orig => orig.RelatoFiscalizacao))
                .ForMember(dest => dest.Relato, opt => opt.MapFrom(orig => orig.Relato))
                .ForMember(dest => dest.FornecedorId, opt => opt.MapFrom(orig => orig.FornecedorId));

            mapper.CreateMap<Processo, ProcessoViewModel>()
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(orig => orig.Numero))
                .ForMember(dest => dest.RelatoFiscalizacao, opt => opt.MapFrom(orig => orig.RelatoFiscalizacao))
                .ForMember(dest => dest.Relato, opt => opt.MapFrom(orig => orig.Relato.DataFormatada()))
                .ForMember(dest => dest.FornecedorId, opt => opt.MapFrom(orig => orig.FornecedorId));
        }
    }

    public class ProcessoListaViewModel
    {
        public string Id { get; set; }

        public string Numero { get; set; }

        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }

        public string FiscalResponsavel { get; set; }

        public string Relato { get; set; }


        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<ProcessoDTO, ProcessoListaViewModel>()
               .ForMember(dest => dest.Numero, opt => opt.MapFrom(orig => orig.Numero))
               .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(orig => orig.Cnpj.FormatarCNPJ()))
               .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(orig => orig.RazaoSocial))
               .ForMember(dest => dest.FiscalResponsavel, opt => opt.MapFrom(orig => orig.FiscalResponsavel))
               .ForMember(dest => dest.Relato, opt => opt.MapFrom(orig => orig.Relato.DataFormatada()))
               ;
        }
    }
}
