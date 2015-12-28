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

using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;

namespace Expression2Sql
{
    class MemberExpression2Sql : BaseExpression2Sql<MemberExpression>
    {
        private static object GetValue(MemberExpression expr)
        {
            object value;
            var field = expr.Member as FieldInfo;
            if (field != null)
            {
                value = field.GetValue(((ConstantExpression)expr.Expression).Value);
            }
            else
            {
                value = ((PropertyInfo)expr.Member).GetValue(((ConstantExpression)expr.Expression).Value, null);
            }
            return value;
        }

        private SqlPack AggregateFunctionParser(MemberExpression expression, SqlPack sqlPack)
        {
            string aggregateFunctionName = new StackTrace(true).GetFrame(1).GetMethod().Name.ToLower();

            string tableName = expression.Member.DeclaringType.Name;
            string columnName = expression.Member.Name;

            sqlPack.SetTableAlias(tableName);
            string tableAlias = sqlPack.GetTableAlias(tableName);

            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableName += " " + tableAlias;
                columnName = tableAlias + "." + columnName;
            }
            sqlPack.Sql.AppendFormat("select {0}({1}) from {2}", aggregateFunctionName, columnName, tableName);
            return sqlPack;
        }

        protected override SqlPack Select(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
            string tableAlias = sqlPack.GetTableAlias(expression.Member.DeclaringType.Name);
            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableAlias += ".";
            }
            sqlPack.SelectFields.Add(tableAlias + expression.Member.Name);
            return sqlPack;
        }

        protected override SqlPack Join(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
            string tableAlias = sqlPack.GetTableAlias(expression.Member.DeclaringType.Name);
            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableAlias += ".";
            }
            sqlPack += " " + tableAlias + expression.Member.Name;

            return sqlPack;
        }

        protected override SqlPack Where(MemberExpression expression, SqlPack sqlPack)
        {
            if (expression.Expression.NodeType == ExpressionType.Constant)
            {
                object value = GetValue(expression);
                sqlPack.AddDbParameter(value);
            }
            else if (expression.Expression.NodeType == ExpressionType.Parameter)
            {
                sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
                string tableAlias = sqlPack.GetTableAlias(expression.Member.DeclaringType.Name);
                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableAlias += ".";
                }
                sqlPack += " " + tableAlias + expression.Member.Name;
            }

            return sqlPack;
        }

        protected override SqlPack In(MemberExpression expression, SqlPack sqlPack)
        {
            var field = expression.Member as FieldInfo;
            if (field != null)
            {
                object val = field.GetValue(((ConstantExpression)expression.Expression).Value);

                if (val != null)
                {
                    string itemJoinStr = "";
                    IEnumerable array = val as IEnumerable;
                    foreach (var item in array)
                    {
                        if (field.FieldType.Name == "String[]")
                        {
                            itemJoinStr += string.Format(",'{0}'", item);
                        }
                        else
                        {
                            itemJoinStr += string.Format(",{0}", item);
                        }
                    }

                    if (itemJoinStr.Length > 0)
                    {
                        itemJoinStr = itemJoinStr.Remove(0, 1);
                        itemJoinStr = string.Format("({0})", itemJoinStr);
                        sqlPack += itemJoinStr;
                    }
                }
            }

            return sqlPack;
        }

        protected override SqlPack GroupBy(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
            sqlPack += sqlPack.GetTableAlias(expression.Member.DeclaringType.Name) + "." + expression.Member.Name;
            return sqlPack;
        }

        protected override SqlPack OrderBy(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
            sqlPack += sqlPack.GetTableAlias(expression.Member.DeclaringType.Name) + "." + expression.Member.Name;
            return sqlPack;
        }

        protected override SqlPack Max(MemberExpression expression, SqlPack sqlPack)
        {
            return AggregateFunctionParser(expression, sqlPack);
        }

        protected override SqlPack Min(MemberExpression expression, SqlPack sqlPack)
        {
            return AggregateFunctionParser(expression, sqlPack);
        }

        protected override SqlPack Avg(MemberExpression expression, SqlPack sqlPack)
        {
            return AggregateFunctionParser(expression, sqlPack);
        }

        protected override SqlPack Count(MemberExpression expression, SqlPack sqlPack)
        {
            return AggregateFunctionParser(expression, sqlPack);
        }

        protected override SqlPack Sum(MemberExpression expression, SqlPack sqlPack)
        {
            return AggregateFunctionParser(expression, sqlPack);
        }
    }
}