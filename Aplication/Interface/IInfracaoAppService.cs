using Aplication.ViewModel;
using Domain.Entidade;
using Shared.Interface.AppService;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace Aplication.Interface
{
    public interface IInfracaoAppService : IBaseCrudAppService<InfracaoViewModel, Infracao>
    {
        IResultadoApplication<ICollection<InfracaoListaViewModel>> Listar(string Id);


    }
}
