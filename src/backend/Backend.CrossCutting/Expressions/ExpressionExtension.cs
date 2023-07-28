using System.Linq.Expressions;

namespace Backend.CrossCutting.Expressions;

public static class ExpressionExtension
{
    public static Expression<Func<TEntity, bool>> CombinarExpressions<TEntity>(this Expression<Func<TEntity, bool>> queryBase, Expression<Func<TEntity, bool>> query)
    {
        var parametro = Expression.Parameter(typeof(TEntity), "entity");
        var body = Expression.AndAlso(Expression.Invoke(queryBase, parametro), Expression.Invoke(query, parametro));

        return Expression.Lambda<Func<TEntity, bool>>(body, parametro);
    }
}