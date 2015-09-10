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
    class ConstantExpression2Sql : BaseExpression2Sql<ConstantExpression>
    {
        protected override SqlPack Where(ConstantExpression expression, SqlPack sqlPack)
        {
            sqlPack.AddDbParameter(expression.Value);
            return sqlPack;
        }

        protected override SqlPack In(ConstantExpression expression, SqlPack sqlPack)
        {
            if (expression.Type.Name == "String")
            {
                sqlPack.Sql.AppendFormat("'{0}',", expression.Value);                
            }
            else
            {
                sqlPack.Sql.AppendFormat("{0},", expression.Value);
            }
            return sqlPack;
        }
    }
}