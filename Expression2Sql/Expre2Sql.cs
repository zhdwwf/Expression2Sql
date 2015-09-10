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
	public static class Expre2Sql
	{
		public static DatabaseType DatabaseType { get; set; }

		public static void Init(DatabaseType dbType)
		{
			DatabaseType = dbType;
		}

		public static Expression2SqlCore<T> Delete<T>()
		{
			return new Expression2SqlCore<T>(DatabaseType).Delete();
		}

		public static Expression2SqlCore<T> Update<T>(Expression<Func<object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Update(expression);
		}

		public static Expression2SqlCore<T> Select<T>(Expression<Func<T, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2>(Expression<Func<T, T2, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}
		public static Expression2SqlCore<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Select(expression);
		}

		public static Expression2SqlCore<T> Max<T>(Expression<Func<T, object>> expression)
		{
			return new Expression2SqlCore<T>(DatabaseType).Max(expression);
		}

		public static Expression2SqlCore<T> Min<T>(Expression<Func<T, object>> expression)
		{
			return new Expression2SqlCore<T>(DatabaseType).Min(expression);
		}

		public static Expression2SqlCore<T> Avg<T>(Expression<Func<T, object>> expression)
		{
			return new Expression2SqlCore<T>(DatabaseType).Avg(expression);
		}

		public static Expression2SqlCore<T> Count<T>(Expression<Func<T, object>> expression = null)
		{
			return new Expression2SqlCore<T>(DatabaseType).Count(expression);
		}

		public static Expression2SqlCore<T> Sum<T>(Expression<Func<T, object>> expression)
		{
			return new Expression2SqlCore<T>(DatabaseType).Sum(expression);
		}
	}
}
