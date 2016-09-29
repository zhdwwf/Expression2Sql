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
    class UnaryExpression2Sql : BaseExpression2Sql<UnaryExpression>
    {
        protected override SqlBuilder Select(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Select(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Where(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Where(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder GroupBy(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.GroupBy(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder OrderBy(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.OrderBy(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Max(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Max(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Min(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Min(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Avg(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Avg(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Count(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Count(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Sum(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Sum(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }
    }
}
