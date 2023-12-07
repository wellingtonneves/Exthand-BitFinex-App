using Best.Buy.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Best.Buy.Repository.Extensions
{
    //public static class QueryCacheExtensions
    //{
    //    private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    //    private const int AbsoluteExpirationSeconds = 60;

    //    private static string GetCacheKey(IQueryable query)
    //    {
    //        var queryString = query.ToQueryString();
    //        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(queryString));
    //        return Convert.ToBase64String(hash);
    //    }

    //    public static PagedList<T> FromCache<T>(this IQueryable<T> query, PagedList<T> ret)
    //    {
    //        var key = GetCacheKey(query);

    //        var result = _cache.GetOrCreate(key, cache =>
    //        {
    //            cache.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(AbsoluteExpirationSeconds);
    //            return ret;
    //        }) ?? new PagedList<T>();

    //        return result;
    //    }

    //    public static async Task<PagedList<T>> FromCacheAsync<T>(this IQueryable<T> query, 
    //        CancellationToken cancellationToken = default)
    //    {
    //        var key = GetCacheKey(query);

    //        var result = await _cache.GetOrCreateAsync(key, cache =>
    //        {
    //            cache.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(AbsoluteExpirationSeconds);
    //            return query.ToListAsync(cancellationToken);
    //        }) ?? new PagedList<T>();

    //        return result;
    //    }

    //    public static void Clear()
    //    {
    //        _cache.Dispose();
    //        _cache = new MemoryCache(new MemoryCacheOptions());
    //    }
    //}
}
