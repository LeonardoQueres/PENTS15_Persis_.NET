using Domain.DTO;
using Domain.Entidade;
using Domain.Interface.Repository;
using FileSys.Shared.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class InfracaoRepository : BaseCrudRepository<Infracao>, IInfracaoRepository
    {
        private readonly AdminContext dbContext;

        public InfracaoRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IDictionary<string, string> RecuperarDropDown()
        {
            throw new NotImplementedException();
        }


        IEnumerable<InfracaoDTO> IInfracaoRepository.Listar(string Id)
        {
            return (from infracao in context.Set<Infracao>()
                    join processos in context.Set<Processo>() on infracao.ProcessoId equals processos.Id into processo
                    from processos in processo.DefaultIfEmpty()
                    join fornecedores in context.Set<Fornecedor>() on processos.FornecedorId equals fornecedores.Id into fornecedor
                    from fornecedores in fornecedor.DefaultIfEmpty()
                    where processos.Id == Id
                    select new InfracaoDTO()
                    {
                        Id = infracao.Id,
                        ProcessoId = processos.Id,
                        RazaoSocial = fornecedores.RazaoSocial,
                        Cnpj = fornecedores.Cnpj,
                        Multa = infracao.Multa
                    }).ToList();
        }

        void IInfracaoRepository.RemoverTodos(string ProcessoId)
        {
            dbContext.Set<Infracao>()
                 .Where(x => x.ProcessoId == ProcessoId)
                 .ToList()
                 .ForEach(x => base.Remover(x));
        }
    }
}
