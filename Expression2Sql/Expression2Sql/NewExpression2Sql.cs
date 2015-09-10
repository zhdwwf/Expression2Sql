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
using System.Reflection;

namespace Expression2Sql
{
	class NewExpression2Sql : BaseExpression2Sql<NewExpression>
	{
		protected override SqlPack Update(NewExpression expression, SqlPack sqlPack)
		{
			for (int i = 0; i < expression.Members.Count; i++)
			{
				MemberInfo m = expression.Members[i];
				ConstantExpression c = expression.Arguments[i] as ConstantExpression;
				sqlPack += m.Name + " =";
				sqlPack.AddDbParameter(c.Value);
				sqlPack += ",";
			}
			if (sqlPack[sqlPack.Length - 1] == ',')
			{
				sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
			}
			return sqlPack;
		}

		protected override SqlPack Select(NewExpression expression, SqlPack sqlPack)
		{
			foreach (Expression item in expression.Arguments)
			{
				Expression2SqlProvider.Select(item, sqlPack);
			}
			return sqlPack;
		}

		protected override SqlPack GroupBy(NewExpression expression, SqlPack sqlPack)
		{
			foreach (Expression item in expression.Arguments)
			{
				Expression2SqlProvider.GroupBy(item, sqlPack);
			}
			return sqlPack;
		}

		protected override SqlPack OrderBy(NewExpression expression, SqlPack sqlPack)
		{
			foreach (Expression item in expression.Arguments)
			{
				Expression2SqlProvider.OrderBy(item, sqlPack);
			}
			return sqlPack;
		}
	}
}
