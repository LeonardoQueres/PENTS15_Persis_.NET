using AutoMapper;
using Domain.Entidade;
using Shared.ViewModel;
using System.Collections.Generic;

namespace Aplication.ViewModel
{
    public class ProdutoViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Estoque { get; set; }
        public string FornecedorId { get; set; }

        #region Campos da Tela 
        public IDictionary<string, string> Fornecedores { get; set; }
        #endregion
        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<ProdutoViewModel, Produto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(orig => orig.Nome))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(orig => orig.Marca))
                .ForMember(dest => dest.Estoque, opt => opt.MapFrom(orig => orig.Estoque))
                .ForMember(dest => dest.FornecedorId, opt => opt.MapFrom(orig => orig.FornecedorId));

            mapper.CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(orig => orig.Nome))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(orig => orig.Marca))
                .ForMember(dest => dest.Estoque, opt => opt.MapFrom(orig => orig.Estoque))
                .ForMember(dest => dest.FornecedorId, opt => opt.MapFrom(orig => orig.FornecedorId));

        }
    }
}
