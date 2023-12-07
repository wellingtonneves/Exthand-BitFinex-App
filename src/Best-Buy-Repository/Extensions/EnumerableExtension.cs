using Best.Buy.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Best.Buy.Repository.Extensions
{
    public static class EnumerableExtension
    {
        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private const int AbsoluteExpirationSeconds = 60;

        private static string GetCacheKey(IQueryable query)
        {
            var queryString = query.ToQueryString();
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(queryString));
            return Convert.ToBase64String(hash);
        }

        public static async Task<PagedList<T>> PaginateAsync<T>(this IQueryable<T> items, int page, PageSize pageSize = PageSize.TEN)
        {
            var key = GetCacheKey(items);

            PagedList<T> result = (PagedList<T>)_cache.Get(key);
            if (result != null) return result;
            
            var count = await items.CountAsync();
            
            T[] pagedItems;
            if (page > 0)
                pagedItems = await items.Skip((page - 1) * (int)pageSize).Take((int)pageSize).ToArrayAsync();
            else
                pagedItems = await items.ToArrayAsync();

            result = new PagedList<T>(pagedItems, count, page, pageSize);
            _cache.Set(key, result);

            return result;
        }
    }
}
