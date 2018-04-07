using AutoMapper;
using Domain.Entidade;
using Domain.Enum;
using Shared.Tools;
using Shared.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Aplication.ViewModel
{
    public class EnderecoTelaViewModel
    {
        public EnderecoTelaViewModel()
        {

        }

        public EnderecoTelaViewModel(EnderecoViewModel endereco)
        {
            ApenasUmEndereco = true;
            Enderecos = new EnderecoViewModel[1] { endereco };
        }

        public EnderecoTelaViewModel(IEnumerable<EnderecoViewModel> enderecos)
        {
            ApenasUmEndereco = false;
            Enderecos = (enderecos.Count() > 0 ? enderecos.ToArray() : null);
        }

        public bool ApenasUmEndereco { get; set; }

        public EnderecoViewModel[] Enderecos { get; set; }

        #region Campos da tela

        public IDictionary<string, string> Ufs { get; set; }

        #endregion
    }

    public class EnderecoViewModel : BaseViewModel
    {
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        public string Bairro { get; set; }

        public string Municipio { get; set; }

        public string UfCodigo { get; set; }
        public string UfNome { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }

        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<EnderecoViewModel, Endereco>()
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(orig => orig.UfCodigo.ToEnum<UfEnum>()))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(orig => orig.Logradouro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(orig => orig.Numero))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(orig => orig.Bairro))
                .ForMember(dest => dest.Municipio, opt => opt.MapFrom(orig => orig.Municipio))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(orig => orig.Cep))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(orig => orig.Complemento))
                ;

            mapper.CreateMap<Endereco, EnderecoViewModel>()
                .ForMember(dest => dest.UfCodigo, opt => opt.MapFrom(orig => orig.Uf.Valor()))
                .ForMember(dest => dest.UfNome, opt => opt.MapFrom(orig => orig.Uf.Descricao()))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(orig => orig.Logradouro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(orig => orig.Numero))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(orig => orig.Bairro))
                .ForMember(dest => dest.Municipio, opt => opt.MapFrom(orig => orig.Municipio))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(orig => orig.Cep))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(orig => orig.Complemento))
                ;
        }
    }
}
