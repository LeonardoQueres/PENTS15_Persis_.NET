using Aplication.AppService;
using Aplication.Interface;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Service;
using Infra.Data;
using Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public class Configuracao
    {
        public static void InjecaoDependencia(IServiceCollection services)
        {
            // Deixar em ordem alfabetica de entidade para ficar mais facil de procurar
            #region Endereco
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            #endregion

            #region Fornecedor
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            #endregion

            #region Infracao
            services.AddScoped<IInfracaoAppService, InfracaoAppService>();
            services.AddScoped<IInfracaoService, InfracaoService>();
            services.AddScoped<IInfracaoRepository, InfracaoRepository>();
            #endregion

            #region Produto
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            #endregion

            #region Processo
            services.AddScoped<IProcessoAppService, ProcessoAppService>();
            services.AddScoped<IProcessoService, ProcessoService>();
            services.AddScoped<IProcessoRepository, ProcessoRepository>();
            #endregion

            services.AddScoped<AdminContext>();
        }
    }
}
