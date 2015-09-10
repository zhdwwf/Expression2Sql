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
		protected virtual SqlPack Update(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Update方法");
		}
		protected virtual SqlPack Select(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Select方法");
		}
		protected virtual SqlPack Join(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Join方法");
		}
		protected virtual SqlPack Where(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Where方法");
		}
		protected virtual SqlPack In(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.In方法");
		}
		protected virtual SqlPack GroupBy(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.GroupBy方法");
		}
		protected virtual SqlPack OrderBy(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.OrderBy方法");
		}
		protected virtual SqlPack Max(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Max方法");
		}
		protected virtual SqlPack Min(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Min方法");
		}
		protected virtual SqlPack Avg(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Avg方法");
		}
		protected virtual SqlPack Count(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Count方法");
		}
		protected virtual SqlPack Sum(T expression, SqlPack sqlPack)
		{
			throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Sum方法");
		}


		public SqlPack Update(Expression expression, SqlPack sqlPack)
		{
			return Update((T)expression, sqlPack);
		}
		public SqlPack Select(Expression expression, SqlPack sqlPack)
		{
			return Select((T)expression, sqlPack);
		}
		public SqlPack Join(Expression expression, SqlPack sqlPack)
		{
			return Join((T)expression, sqlPack);
		}
		public SqlPack Where(Expression expression, SqlPack sqlPack)
		{
			return Where((T)expression, sqlPack);
		}
		public SqlPack In(Expression expression, SqlPack sqlPack)
		{
			return In((T)expression, sqlPack);
		}
		public SqlPack GroupBy(Expression expression, SqlPack sqlPack)
		{
			return GroupBy((T)expression, sqlPack);
		}
		public SqlPack OrderBy(Expression expression, SqlPack sqlPack)
		{
			return OrderBy((T)expression, sqlPack);
		}
		public SqlPack Max(Expression expression, SqlPack sqlPack)
		{
			return Max((T)expression, sqlPack);
		}
		public SqlPack Min(Expression expression, SqlPack sqlPack)
		{
			return Min((T)expression, sqlPack);
		}
		public SqlPack Avg(Expression expression, SqlPack sqlPack)
		{
			return Avg((T)expression, sqlPack);
		}
		public SqlPack Count(Expression expression, SqlPack sqlPack)
		{
			return Count((T)expression, sqlPack);
		}
		public SqlPack Sum(Expression expression, SqlPack sqlPack)
		{
			return Sum((T)expression, sqlPack);
		}
	}
}
