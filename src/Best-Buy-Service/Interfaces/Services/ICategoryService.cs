using Best.Buy.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Best.Buy.Service.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();
    }
}
