using Expression2Sql;
using System;
using System.Collections.Generic;

namespace Expression2SqlTest
{
	/// <summary>
	/// Expression2Sql Sample Code
	/// Technology Blog：http://www.cnblogs.com/strangecity
	/// Expression2Sql Introduce：http://www.cnblogs.com/StrangeCity/p/4795117.html
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Expression2SqlTest";


			//通过静态属性DatabaseType或者静态方法Init均可配置数据库类型
            ExpressionToSql.DatabaseType = DatabaseType.SQLServer;
            ExpressionToSql.Init(DatabaseType.SQLServer);

            Printf(
                ExpressionToSql.Select<UserInfo>(),
                "查询单表所有字段"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Id),
                "查询单表单个字段"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => new { u.Id, u.Name }),
                "查询单表多个字段"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Id).
                          Where(u => u.Name.Like("b")),
                "查询单表，带where Like条件"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Id).
                          Where(u => u.Name.LikeLeft("b")),
                "查询单表，带where LikeLeft条件"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Id).
                          Where(u => u.Name.LikeRight("b")),
                "查询单表，带where LikeRight条件"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Name).
                          Where(u => u.Id.In(1, 2, 3)),
                "查询单表，带where in条件，写法一"
            );

            int[] aryId = { 1, 2, 3 };
            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Name).
                          Where(u => u.Id.In(aryId)),
                "查询单表，带where in条件，写法二"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Name).
                          Where(u => u.Name.In(new string[] { "a", "b" })),
                "查询单表，带where in条件，写法三"
            );

            Printf(
                ExpressionToSql.Select<UserInfo>(u => u.Id).
                          Where(
                                u => u.Name == "b"
                                  && u.Id > 2
                                  && u.Name != null
                                  && u.Id > int.MinValue
                                  && u.Id < int.MaxValue
                                  && u.Id.In(1, 2, 3)
                                  && u.Name.Like("a")
                                  && u.Name.LikeLeft("b")
                                  && u.Name.LikeRight("c")
                                  || u.Id == null
                                ),
                "查询单表，带多个where条件"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                           Join<Account>((u, a) => u.Id == a.UserId),
                 "多表Join关联查询"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                           InnerJoin<Account>((u, a) => u.Id == a.UserId),
                 "多表InnerJoin关联查询"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                           LeftJoin<Account>((u, a) => u.Id == a.UserId),
                 "多表LeftJoin关联查询"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                           RightJoin<Account>((u, a) => u.Id == a.UserId),
                 "多表RightJoin关联查询"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                           FullJoin<Account>((u, a) => u.Id == a.UserId),
                 "多表FullJoin关联查询"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo, Account, Student, Class, City, Country>((u, a, s, d, e, f) =>
                           new { u.Id, a.Name, StudentName = s.Name, ClassName = d.Name, e.CityName, CountryName = f.Name }).
                           Join<Account>((u, a) => u.Id == a.UserId).
                           LeftJoin<Account, Student>((a, s) => a.Id == s.AccountId).
                           RightJoin<Student, Class>((s, c) => s.Id == c.UserId).
                           InnerJoin<Class, City>((c, d) => c.CityId == d.Id).
                           FullJoin<City, Country>((c, d) => c.CountryId == d.Id).
                           Where(u => u.Id != null),
                 "多表复杂关联查询"
            );

            Printf(
                 ExpressionToSql.Count<UserInfo>(u => u.Id).
                           GroupBy(u => u.Name),
                 "GroupBy分组查询"
            );

            Printf(
                 ExpressionToSql.Select<UserInfo>().
                           OrderBy(u => u.Id),
                 "OrderBy排序"
            );

            Printf(
                 ExpressionToSql.Max<UserInfo>(u => u.Id),
                 "返回一列中的最大值。NULL 值不包括在计算中。"
            );

            Printf(
                 ExpressionToSql.Min<UserInfo>(u => u.Id),
                 "返回一列中的最小值。NULL 值不包括在计算中。"
            );

            Printf(
                 ExpressionToSql.Avg<UserInfo>(u => u.Id),
                 "返回数值列的平均值。NULL 值不包括在计算中。"
            );

            Printf(
                 ExpressionToSql.Count<UserInfo>(),
                 "返回表中的记录数"
            );

            Printf(
                 ExpressionToSql.Count<UserInfo>(u => u.Id),
                 "返回指定列的值的数目（NULL 不计入）"
            );

            Printf(
                 ExpressionToSql.Sum<UserInfo>(u => u.Id),
                 "返回数值列的总数（总额）。"
            );

            Printf(
                 ExpressionToSql.Delete<UserInfo>(),
                 "全表删除"
            );

            Printf(
                 ExpressionToSql.Delete<UserInfo>().
                           Where(u => u.Id == null),
                 "根据where条件删除指定表记录"
            );

            Printf(
                 ExpressionToSql.Update<UserInfo>(() => new { Name = "", Sex = 1, Email = "123456@qq.com" }),
                 "全表更新"
            );

            Printf(
                 ExpressionToSql.Update<UserInfo>(() => new { Name = "", Sex = 1, Email = "123456@qq.com" }).
                           Where(u => u.Id == 1),
                 "根据where条件更新指定表记录"
            );


			//to be continued...
		}

		private static void Printf<T>(Expression2SqlCore<T> expression2Sql, string description = "")
		{
			if (!string.IsNullOrWhiteSpace(description))
			{
				Console.WriteLine(description);
			}
			Console.WriteLine(expression2Sql.SqlStr);
			foreach (KeyValuePair<string, object> item in expression2Sql.DbParams)
			{
				Console.WriteLine(item.ToString());
			}
			Console.WriteLine();
			Console.WriteLine();
		}
	}
}
