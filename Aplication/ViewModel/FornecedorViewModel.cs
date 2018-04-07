using AutoMapper;
using Domain.DTO;
using Domain.Entidade;
using Shared.Tools;
using Shared.ViewModel;
using System;
using System.Collections.Generic;

namespace Aplication.ViewModel
{
    public class FornecedorViewModel : BaseViewModel
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string ReceitaBruta { get; set; }
        public EnderecoTelaViewModel TelaEnderecos { get; set; } = new EnderecoTelaViewModel();

        #region Campos da Tela 
        public IDictionary<string, string> Ufs { get; set; }
        #endregion


        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<FornecedorViewModel, Fornecedor>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(orig => orig.TelaEnderecos.Enderecos))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(orig => orig.Cnpj.RemoverCaracteres()))
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(orig => orig.RazaoSocial))
                .ForMember(dest => dest.InscricaoMunicipal, opt => opt.MapFrom(orig => orig.InscricaoMunicipal.RemoverCaracteres()))
                .ForMember(dest => dest.ReceitaBruta, opt => opt.MapFrom(orig => orig.ReceitaBruta));

            mapper.CreateMap<Fornecedor, FornecedorViewModel>()
                .ForMember(dest => dest.TelaEnderecos, opt => opt.MapFrom(orig => new EnderecoTelaViewModel(Mapper.Map<IEnumerable<Endereco>, EnderecoViewModel[]>(orig.Enderecos))))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(orig => orig.Cnpj.FormatarCNPJ()))
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(orig => orig.RazaoSocial))
                .ForMember(dest => dest.InscricaoMunicipal, opt => opt.MapFrom(orig => orig.InscricaoMunicipal.FormataInscricaoMunicipal()))
                .ForMember(dest => dest.ReceitaBruta, opt => opt.MapFrom(orig => orig.ReceitaBruta.FormataValor()));

        }
    }

    public class FornecedorListaViewModel
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string ReceitaBruta { get; set; }
        public string RelatoFiscalizacao { get; set; }
        public DateTime Relato { get; set; }


        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<FornecedorProcessoDTO, FornecedorListaViewModel>()
               .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(orig => orig.Cnpj.FormatarCNPJ()))
               .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(orig => orig.RazaoSocial))
               .ForMember(dest => dest.ReceitaBruta, opt => opt.MapFrom(orig => orig.ReceitaBruta.FormataValor()))
               .ForMember(dest => dest.RelatoFiscalizacao, opt => opt.MapFrom(orig => orig.RelatoFiscalizacao))
               .ForMember(dest => dest.Relato, opt => opt.MapFrom(orig => orig.Relato.DataFormatada()));
        }
    }
}
