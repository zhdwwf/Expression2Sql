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

using System.Linq.Expressions;

namespace Expression2Sql
{
	public interface IExpression2Sql
	{
		SqlBuilder Update(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Select(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Join(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Where(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder In(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder GroupBy(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder OrderBy(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Max(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Min(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Avg(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Count(Expression expression, SqlBuilder sqlBuilder);

		SqlBuilder Sum(Expression expression, SqlBuilder sqlBuilder);
	}
}
