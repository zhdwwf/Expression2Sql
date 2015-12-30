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
    class NewArrayExpression2Sql : BaseExpression2Sql<NewArrayExpression>
    {
        protected override SqlBuilder In(NewArrayExpression expression, SqlBuilder sqlBuilder)
        {
            sqlBuilder += "(";

            foreach (Expression expressionItem in expression.Expressions)
            {
                Expression2SqlProvider.In(expressionItem, sqlBuilder);
            }

            if (sqlBuilder[sqlBuilder.Length - 1] == ',')
            {
                sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            }

            sqlBuilder += ")";

            return sqlBuilder;
        }
    }
}
