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
        protected override SqlPack Select(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Select(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack Where(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Where(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack GroupBy(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.GroupBy(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack OrderBy(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.OrderBy(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack Max(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Max(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack Min(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Min(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack Avg(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Avg(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack Count(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Count(expression, sqlPack);
            return sqlPack;
        }

        protected override SqlPack Sum(ParameterExpression expression, SqlPack sqlPack)
        {
            Expression2SqlProvider.Sum(expression, sqlPack);
            return sqlPack;
        }
    }
}
