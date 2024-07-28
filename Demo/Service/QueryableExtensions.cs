using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.OpenApi.Expressions;

namespace Demo.Service;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, bool desc)
    {
        try{
            var command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(FirstToUpper(orderByProperty));
            var parameter = Expression.Parameter(type, "p");
            if(property==null){
                throw new ArgumentException(string.Format("The orderBy {0} doesn't exist",orderByProperty));
            }
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                            source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }catch(Exception){
            throw new ArgumentException(string.Format("The orderBy {0} doesn't exist",orderByProperty));
        }
    }

    static string FirstToUpper(string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;
        char[] s = str.ToCharArray();
        char c = s[0];
        if ('a' <= c && c <= 'z')
            c = (char)(c & ~0x20);
        s[0] = c;
        return new string(s);
    }
}
