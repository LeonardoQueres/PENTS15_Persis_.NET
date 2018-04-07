using Domain.DTO;
using Domain.Entidade;
using Domain.Interface.Repository;
using FileSys.Shared.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class FornecedorRepository : BaseCrudRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly AdminContext dbContext;

        public FornecedorRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public FornecedorProcessoDTO RecuperarDadosFornecedor(string Id)
        {
            return (from processo in context.Set<Processo>()
                    join fornecedores in context.Set<Fornecedor>() on processo.FornecedorId equals fornecedores.Id into fornecedor
                    from fornecedores in fornecedor.DefaultIfEmpty()
                    where processo.Id == Id
                    select new FornecedorProcessoDTO()
                    {
                        RazaoSocial = fornecedores.RazaoSocial,
                        Cnpj = fornecedores.Cnpj,
                        ReceitaBruta = fornecedores.ReceitaBruta,
                        Relato = processo.Relato,
                        RelatoFiscalizacao = processo.RelatoFiscalizacao
                    }).FirstOrDefault();

        }


        public override IDictionary<string, string> RecuperarDropDown()
        {
            return dbContext.Set<Fornecedor>()
                 .AsNoTracking()
                 .OrderBy(x => x.RazaoSocial)
                 .ToDictionary(x => x.Id, x => x.RazaoSocial)
                 ;
        }
    }
}
