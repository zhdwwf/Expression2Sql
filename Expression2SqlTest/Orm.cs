using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expression2Sql;
using System.Linq.Expressions;
using System.Data;

namespace Expression2SqlTest
{
    class Orm
    {
        public static T Find<T>(ExpressionToSql<T> expression)
        {
            Console.WriteLine(expression.Sql + Environment.NewLine);
            string sql = expression.Sql;
            DataRow dr = DbHelper.ExecuteDataRow(sql, expression.DbParams);
            T entity = Mapping.ToEntity<T>(dr);
            return entity;
        }

        public static List<T> Query<T>(ExpressionToSql<T> expression)
        {
            Console.WriteLine(expression.Sql + Environment.NewLine);
            string sql = expression.Sql;
            DataTable dt = DbHelper.ExecuteDataTable(sql, expression.DbParams);
            List<T> list = Mapping.ToListEntity<T>(dt);
            return list;
        }

        public static int Execute<T>(ExpressionToSql<T> expression)
        {
            Console.WriteLine(expression.Sql + Environment.NewLine);
            string sql = expression.Sql;
            return DbHelper.ExecuteNonQuery(sql);
        }

        public static object GetValue<T>(ExpressionToSql<T> expression)
        {
            Console.WriteLine(expression.Sql + Environment.NewLine);
            string sql = expression.Sql;
            return DbHelper.ExecuteScalar(sql);
        }

    }
}
