using Expression2Sql;
using System;
using System.Linq.Expressions;

namespace Expression2Sql
{
    public static class ExpressionToSqlOracle
    {


        private static ExpressionToSql<T> CreateExpressionToSql<T>()
        {
            return new ExpressionToSql<T>(new OracleSqlParser());
        }

        public static ExpressionToSql<T> Insert<T>(Expression<Func<object>> expression = null)
        {
            return CreateExpressionToSql<T>().Insert(expression);
        }

        public static ExpressionToSql<T> Delete<T>()
        {
            return CreateExpressionToSql<T>().Delete();
        }

        public static ExpressionToSql<T> Update<T>(Expression<Func<object>> expression = null)
        {
            return CreateExpressionToSql<T>().Update(expression);
        }

        public static ExpressionToSql<T> Select<T>(Expression<Func<T, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2>(Expression<Func<T, T2, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }
        public static ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public static ExpressionToSql<T> Max<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Max(expression);
        }

        public static ExpressionToSql<T> Min<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Min(expression);
        }

        public static ExpressionToSql<T> Avg<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Avg(expression);
        }

        public static ExpressionToSql<T> Count<T>(Expression<Func<T, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Count(expression);
        }

        public static ExpressionToSql<T> Sum<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Sum(expression);
        }
    }
}
