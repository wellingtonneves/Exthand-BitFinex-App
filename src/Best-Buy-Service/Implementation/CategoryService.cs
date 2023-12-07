using AutoMapper;
using Best.Buy.Service.Interfaces.Services;
using Best.Buy.DTO;
using Best.Buy.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best.Buy.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CategoryService(UnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            return _mapper.Map<List<CategoryResponse>>(
                await _unitOfWork.CategoryRepository.GetAsync(null, (c=> c.OrderBy(a=> a.CategoryName)))); 
        }
    }
}