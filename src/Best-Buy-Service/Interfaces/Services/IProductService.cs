using Best.Buy.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Best.Buy.Service.Interfaces.Services
{
    public interface IProductService
    {
        Task<PagedList<ProductResponse>> GetProductsAsync(ProductRequest requestProduct);
    }
}
