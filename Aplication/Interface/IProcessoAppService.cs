using Aplication.ViewModel;
using Domain.Entidade;
using Shared.Interface.AppService;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace Aplication.Interface
{
    public interface IProcessoAppService : IBaseCrudAppService<ProcessoViewModel, Processo>
    {
        IResultadoApplication<ICollection<ProcessoListaViewModel>> Listar();
    }
}
