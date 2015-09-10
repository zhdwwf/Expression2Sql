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
		static Dictionary<string, Action<MethodCallExpression, SqlPack>> _Methods = new Dictionary<string, Action<MethodCallExpression, SqlPack>>
        {
            {"Like",Like},
            {"LikeLeft",LikeLeft},
            {"LikeRight",LikeRight},
            {"In",In}
        };

		private static void In(MethodCallExpression expression, SqlPack sqlPack)
		{
			Expression2SqlProvider.Where(expression.Arguments[0], sqlPack);
			sqlPack += " in";
			Expression2SqlProvider.In(expression.Arguments[1], sqlPack);
		}

		private static void Like(MethodCallExpression expression, SqlPack sqlPack)
		{
			if (expression.Object != null)
			{
				Expression2SqlProvider.Where(expression.Object, sqlPack);
			}
			Expression2SqlProvider.Where(expression.Arguments[0], sqlPack);
			sqlPack += " like '%' +";
			Expression2SqlProvider.Where(expression.Arguments[1], sqlPack);
			sqlPack += " + '%'";
		}

		private static void LikeLeft(MethodCallExpression expression, SqlPack sqlPack)
		{
			if (expression.Object != null)
			{
				Expression2SqlProvider.Where(expression.Object, sqlPack);
			}
			Expression2SqlProvider.Where(expression.Arguments[0], sqlPack);
			sqlPack += " like '%' +";
			Expression2SqlProvider.Where(expression.Arguments[1], sqlPack);
		}

		private static void LikeRight(MethodCallExpression expression, SqlPack sqlPack)
		{
			if (expression.Object != null)
			{
				Expression2SqlProvider.Where(expression.Object, sqlPack);
			}
			Expression2SqlProvider.Where(expression.Arguments[0], sqlPack);
			sqlPack += " like ";
			Expression2SqlProvider.Where(expression.Arguments[1], sqlPack);
			sqlPack += " + '%'";
		}


		protected override SqlPack Where(MethodCallExpression expression, SqlPack sqlPack)
		{
			var key = expression.Method;
			if (key.IsGenericMethod)
			{
				key = key.GetGenericMethodDefinition();
			}

			Action<MethodCallExpression, SqlPack> action;
			if (_Methods.TryGetValue(key.Name, out action))
			{
				action(expression, sqlPack);
				return sqlPack;
			}

			throw new NotImplementedException("无法解析方法" + expression.Method);
		}
	}
}