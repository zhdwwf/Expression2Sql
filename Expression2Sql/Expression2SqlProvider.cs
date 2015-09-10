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
    internal class Expression2SqlProvider
    {
        private static IExpression2Sql GetExpression2Sql(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "不能为null");
            }

            if (expression is BinaryExpression)
            {
                return new BinaryExpression2Sql();
            }
            if (expression is BlockExpression)
            {
                throw new NotImplementedException("未实现的BlockExpression2Sql");
            }
            if (expression is ConditionalExpression)
            {
                throw new NotImplementedException("未实现的ConditionalExpression2Sql");
            }
            if (expression is ConstantExpression)
            {
                return new ConstantExpression2Sql();
            }
            if (expression is DebugInfoExpression)
            {
                throw new NotImplementedException("未实现的DebugInfoExpression2Sql");
            }
            if (expression is DefaultExpression)
            {
                throw new NotImplementedException("未实现的DefaultExpression2Sql");
            }
            if (expression is DynamicExpression)
            {
                throw new NotImplementedException("未实现的DynamicExpression2Sql");
            }
            if (expression is GotoExpression)
            {
                throw new NotImplementedException("未实现的GotoExpression2Sql");
            }
            if (expression is IndexExpression)
            {
                throw new NotImplementedException("未实现的IndexExpression2Sql");
            }
            if (expression is InvocationExpression)
            {
                throw new NotImplementedException("未实现的InvocationExpression2Sql");
            }
            if (expression is LabelExpression)
            {
                throw new NotImplementedException("未实现的LabelExpression2Sql");
            }
            if (expression is LambdaExpression)
            {
                throw new NotImplementedException("未实现的LambdaExpression2Sql");
            }
            if (expression is ListInitExpression)
            {
                throw new NotImplementedException("未实现的ListInitExpression2Sql");
            }
            if (expression is LoopExpression)
            {
                throw new NotImplementedException("未实现的LoopExpression2Sql");
            }
            if (expression is MemberExpression)
            {
                return new MemberExpression2Sql();
            }
            if (expression is MemberInitExpression)
            {
                throw new NotImplementedException("未实现的MemberInitExpression2Sql");
            }
            if (expression is MethodCallExpression)
            {
                return new MethodCallExpression2Sql();
            }
            if (expression is NewArrayExpression)
            {
                return new NewArrayExpression2Sql();
            }
            if (expression is NewExpression)
            {
                return new NewExpression2Sql();
            }
            if (expression is ParameterExpression)
            {
                throw new NotImplementedException("未实现的ParameterExpression2Sql");
            }
            if (expression is RuntimeVariablesExpression)
            {
                throw new NotImplementedException("未实现的RuntimeVariablesExpression2Sql");
            }
            if (expression is SwitchExpression)
            {
                throw new NotImplementedException("未实现的SwitchExpression2Sql");
            }
            if (expression is TryExpression)
            {
                throw new NotImplementedException("未实现的TryExpression2Sql");
            }
            if (expression is TypeBinaryExpression)
            {
                throw new NotImplementedException("未实现的TypeBinaryExpression2Sql");
            }
            if (expression is UnaryExpression)
            {
                return new UnaryExpression2Sql();
            }
            throw new NotImplementedException("未实现的Expression2Sql");
        }

        public static void Update(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Update(expression, sqlPack);
        }

        public static void Select(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Select(expression, sqlPack);
        }

        public static void Join(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Join(expression, sqlPack);
        }

        public static void Where(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Where(expression, sqlPack);
        }

        public static void In(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).In(expression, sqlPack);
        }

        public static void GroupBy(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).GroupBy(expression, sqlPack);
        }

        public static void OrderBy(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).OrderBy(expression, sqlPack);
        }

        public static void Max(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Max(expression, sqlPack);
        }

        public static void Min(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Min(expression, sqlPack);
        }

        public static void Avg(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Avg(expression, sqlPack);
        }

        public static void Count(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Count(expression, sqlPack);
        }

        public static void Sum(Expression expression, SqlPack sqlPack)
        {
            GetExpression2Sql(expression).Sum(expression, sqlPack);
        }
    }
}
