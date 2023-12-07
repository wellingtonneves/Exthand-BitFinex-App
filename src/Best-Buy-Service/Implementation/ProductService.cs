using AutoMapper;
using Best.Buy.Service.Interfaces.Services;
using Best.Buy.DTO;
using Best.Buy.Repository;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Best.Buy.DTO.Models;
using System.Linq.Expressions;
using System;
using Best.Buy.Repository.Extensions;

namespace Best.Buy.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductService(UnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedList<ProductResponse>> GetProductsAsync(
            ProductRequest productRequest)
        {
            Expression<Func<Product, bool>> filter = null;

            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null;

            if (productRequest.CategoryId != null)
                filter = (f => (f.CategoryId == productRequest.CategoryId));

            if (productRequest.Name != null)
            {
                if (filter == null)
                    filter = (f => (f.Name.Contains(productRequest.Name)));
                else
                    filter = filter.And(f => (f.Name.Contains(productRequest.Name)));
            }
            
            if (productRequest.OrderColumn != null)
            {
                switch (productRequest.OrderColumn)
                {
                    case "Name":
                        {
                            orderBy = productRequest.Ascending ? 
                                (o => o.OrderBy(a => a.Name)) : 
                                (o => o.OrderByDescending(a => a.Name));
                            break;
                        }

                    case "Price":
                        {
                            orderBy = productRequest.Ascending ?
                                (o => o.OrderBy(a => a.Price)) :
                                (o => o.OrderByDescending(a => a.Price));
                            break;
                        }
                }
            }

            var products = 
                await _unitOfWork.ProductsRepository.
                    GetAsync(filter: filter, orderBy,
                    productRequest.Page, productRequest.PageSize, 
                    "Category");

            var response = new PagedList<ProductResponse>
            {
                Total = products.Total,
                CurrentPage = products.CurrentPage,
                PageSize = products.PageSize,
                Pages = (int)Math.Ceiling(products.Total / (double)products.PageSize)
            };

            var result = _mapper.Map(products, response);

            return result;
        }
    }
}
