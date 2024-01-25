using HHD.Domain.Configurations;
using HHD.Domain.Entities.Commons;
using HHD.Domain.Entities.Users;
using HHD.Service.Commons.Helpers;
using HHD.Service.Exceptions;
using Newtonsoft.Json;

namespace HHD.Service.Commons.Extentions;

public static class CollectionExtention
{
    public static IEnumerable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
            where TEntity : Auditable
    {

        var metaData = new PaginationMetaData(source.Count(), @params);

        var json = JsonConvert.SerializeObject(metaData);
        if (HttpContextHelper.ResponseHeaders != null)
        {
            if (HttpContextHelper.ResponseHeaders.ContainsKey("X-Pagination"))
                HttpContextHelper.ResponseHeaders.Remove("X-Pagination");

            HttpContextHelper.ResponseHeaders.Add("X-Pagination", json);
        }

        return @params.PageIndex > 0 && @params.PageSize > 0 ?
            source
            .OrderBy(s => s.Id)
            .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : throw new HHDException(400, "Please, enter valid numbers");
    }

    public static IEnumerable<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> source, PaginationParams @params)
    {
        if (@params.PageIndex < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(@params.PageIndex), "The page index must be greater than or equal to 1.");
        }

        if (@params.PageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(@params.PageSize), "The page size must be greater than or equal to 1.");
        }

        return source.Take((@params.PageSize * (@params.PageIndex - 1))..(@params.PageSize * (@params.PageIndex - 1) + @params.PageSize));
    }
}
