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
        SqlPack Update(Expression expression, SqlPack sqlPack);

        SqlPack Select(Expression expression, SqlPack sqlPack);

        SqlPack Join(Expression expression, SqlPack sqlPack);

        SqlPack Where(Expression expression, SqlPack sqlPack);

        SqlPack In(Expression expression, SqlPack sqlPack);

        SqlPack GroupBy(Expression expression, SqlPack sqlPack);

        SqlPack OrderBy(Expression expression, SqlPack sqlPack);

        SqlPack Max(Expression expression, SqlPack sqlPack);

        SqlPack Min(Expression expression, SqlPack sqlPack);

        SqlPack Avg(Expression expression, SqlPack sqlPack);

        SqlPack Count(Expression expression, SqlPack sqlPack);

        SqlPack Sum(Expression expression, SqlPack sqlPack);
    }
}
