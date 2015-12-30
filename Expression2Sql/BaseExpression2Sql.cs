#region License
/**
 * Copyright (c) 2015, 何志祥 (strangecity@qq.com).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * without warranties or conditions of any kind, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Linq.Expressions;

namespace Expression2Sql
{
	public abstract class BaseExpression2Sql<T> : IExpression2Sql where T : Expression
	{
		protected virtual SqlBuilder Update(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Update方法");
		}
		protected virtual SqlBuilder Select(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Select方法");
		}
		protected virtual SqlBuilder Join(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Join方法");
		}
		protected virtual SqlBuilder Where(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Where方法");
		}
		protected virtual SqlBuilder In(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.In方法");
		}
		protected virtual SqlBuilder GroupBy(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.GroupBy方法");
		}
		protected virtual SqlBuilder OrderBy(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.OrderBy方法");
		}
		protected virtual SqlBuilder Max(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Max方法");
		}
		protected virtual SqlBuilder Min(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Min方法");
		}
		protected virtual SqlBuilder Avg(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Avg方法");
		}
		protected virtual SqlBuilder Count(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Count方法");
		}
		protected virtual SqlBuilder Sum(T expression, SqlBuilder sqlBuilder)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Sum方法");
		}


		public SqlBuilder Update(Expression expression, SqlBuilder sqlBuilder)
		{
			return Update((T)expression, sqlBuilder);
		}
		public SqlBuilder Select(Expression expression, SqlBuilder sqlBuilder)
		{
			return Select((T)expression, sqlBuilder);
		}
		public SqlBuilder Join(Expression expression, SqlBuilder sqlBuilder)
		{
			return Join((T)expression, sqlBuilder);
		}
		public SqlBuilder Where(Expression expression, SqlBuilder sqlBuilder)
		{
			return Where((T)expression, sqlBuilder);
		}
		public SqlBuilder In(Expression expression, SqlBuilder sqlBuilder)
		{
			return In((T)expression, sqlBuilder);
		}
		public SqlBuilder GroupBy(Expression expression, SqlBuilder sqlBuilder)
		{
			return GroupBy((T)expression, sqlBuilder);
		}
		public SqlBuilder OrderBy(Expression expression, SqlBuilder sqlBuilder)
		{
			return OrderBy((T)expression, sqlBuilder);
		}
		public SqlBuilder Max(Expression expression, SqlBuilder sqlBuilder)
		{
			return Max((T)expression, sqlBuilder);
		}
		public SqlBuilder Min(Expression expression, SqlBuilder sqlBuilder)
		{
			return Min((T)expression, sqlBuilder);
		}
		public SqlBuilder Avg(Expression expression, SqlBuilder sqlBuilder)
		{
			return Avg((T)expression, sqlBuilder);
		}
		public SqlBuilder Count(Expression expression, SqlBuilder sqlBuilder)
		{
			return Count((T)expression, sqlBuilder);
		}
		public SqlBuilder Sum(Expression expression, SqlBuilder sqlBuilder)
		{
			return Sum((T)expression, sqlBuilder);
		}
	}
}
