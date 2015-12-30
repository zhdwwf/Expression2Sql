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
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expression2Sql
{
	class MethodCallExpression2Sql : BaseExpression2Sql<MethodCallExpression>
	{
		static Dictionary<string, Action<MethodCallExpression, SqlBuilder>> _Methods = new Dictionary<string, Action<MethodCallExpression, SqlBuilder>>
        {
            {"Like",Like},
            {"LikeLeft",LikeLeft},
            {"LikeRight",LikeRight},
            {"In",In}
        };

		private static new void In(MethodCallExpression expression, SqlBuilder sqlBuilder)
		{
			Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
			sqlBuilder += " in";
			Expression2SqlProvider.In(expression.Arguments[1], sqlBuilder);
		}

		private static void Like(MethodCallExpression expression, SqlBuilder sqlBuilder)
		{
			if (expression.Object != null)
			{
				Expression2SqlProvider.Where(expression.Object, sqlBuilder);
			}
			Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
			sqlBuilder += " like '%' +";
			Expression2SqlProvider.Where(expression.Arguments[1], sqlBuilder);
			sqlBuilder += " + '%'";
		}

		private static void LikeLeft(MethodCallExpression expression, SqlBuilder sqlBuilder)
		{
			if (expression.Object != null)
			{
				Expression2SqlProvider.Where(expression.Object, sqlBuilder);
			}
			Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
			sqlBuilder += " like '%' +";
			Expression2SqlProvider.Where(expression.Arguments[1], sqlBuilder);
		}

		private static void LikeRight(MethodCallExpression expression, SqlBuilder sqlBuilder)
		{
			if (expression.Object != null)
			{
				Expression2SqlProvider.Where(expression.Object, sqlBuilder);
			}
			Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
			sqlBuilder += " like ";
			Expression2SqlProvider.Where(expression.Arguments[1], sqlBuilder);
			sqlBuilder += " + '%'";
		}


		protected override SqlBuilder Where(MethodCallExpression expression, SqlBuilder sqlBuilder)
		{
			var key = expression.Method;
			if (key.IsGenericMethod)
			{
				key = key.GetGenericMethodDefinition();
			}

			Action<MethodCallExpression, SqlBuilder> action;
			if (_Methods.TryGetValue(key.Name, out action))
			{
				action(expression, sqlBuilder);
				return sqlBuilder;
			}

			throw new NotImplementedException("无法解析方法" + expression.Method);
		}
	}
}