using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface IProgressTypeService
    {
        //Task<bool> CreateAsync();

        //Task<bool> UpdateAsync();

        Task<IEnumerable<ProgressType>> GetAllAsync();

        //Task<bool> DeleteAsync();
    }
}