using Domain.DTO;
using Domain.Entidade;
using Domain.Interface.Repository;
using FileSys.Shared.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class ProcessoRepository : BaseCrudRepository<Processo>, IProcessoRepository
    {
        private readonly AdminContext dbContext;

        public ProcessoRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IDictionary<string, string> RecuperarDropDown()
        {
            return dbContext.Set<Processo>()
                 .AsNoTracking()
                 .OrderBy(x => x.Numero)
                 .ToDictionary(x => x.Id, x => x.Numero);
        }

        IEnumerable<ProcessoDTO> IProcessoRepository.Listar()
        {
            return (from processo in context.Set<Processo>()
                    join fornecedores in context.Set<Fornecedor>() on processo.FornecedorId equals fornecedores.Id into fornecedor
                    from fornecedores in fornecedor.DefaultIfEmpty()
                    select new ProcessoDTO()
                    {
                        Id = processo.Id,
                        Numero = processo.Numero,
                        RazaoSocial = fornecedores.RazaoSocial,
                        FiscalResponsavel = processo.FiscalResponsavel,
                        Relato = processo.Relato,
                        Cnpj = fornecedores.Cnpj
                    }).ToList();
        }
    }
}
