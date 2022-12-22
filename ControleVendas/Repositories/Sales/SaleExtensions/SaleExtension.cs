using ControleVendas.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ControleVendas.Repositories.Sales.SaleExtensions
{
    public static class SaleExtension
    {
        public static IQueryable<Sale> FilterAsync(this IQueryable<Sale> query, Expression<Func<Sale, bool>> predicate, Func<IQueryable<Sale>, IIncludableQueryable<Sale, object>> include)
        {
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }
    }
}
