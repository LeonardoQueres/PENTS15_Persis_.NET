using Aplication.ViewModel;
using AutoMapper;

namespace Aplication
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            Shared.Conversores.Configuracao.Registrar(this);
            this.AllowNullCollections = true;

            EnderecoViewModel.Mapping(this);
            FornecedorViewModel.Mapping(this);
            InfracaoViewModel.Mapping(this);
            InfracaoListaViewModel.Mapping(this);
            ProdutoViewModel.Mapping(this);
            ProcessoViewModel.Mapping(this);
            ProcessoListaViewModel.Mapping(this);
        }
    }
}
