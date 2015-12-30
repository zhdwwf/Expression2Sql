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
    class ParameterExpression2Sql : BaseExpression2Sql<ParameterExpression>
    {
        protected override SqlBuilder Select(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Select(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Where(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Where(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder GroupBy(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.GroupBy(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder OrderBy(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.OrderBy(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Max(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Max(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Min(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Min(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Avg(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Avg(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Count(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Count(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Sum(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Sum(expression, sqlBuilder);
            return sqlBuilder;
        }
    }
}
