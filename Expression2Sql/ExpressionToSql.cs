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
    public class ExpressionToSql<T>
    {
        private SqlBuilder _sqlBuilder;

        public string Sql
        {
            get
            {
                return this._sqlBuilder.Sql + ";";
            }
        }
        public Dictionary<string, object> DbParams
        {
            get
            {
                return this._sqlBuilder.DbParams;
            }
        }

        public ExpressionToSql(IDbSqlParser dbSqlParser)
        {
            this._sqlBuilder = new SqlBuilder(dbSqlParser);
        }

        public void Clear()
        {
            this._sqlBuilder.Clear();
        }


        private ExpressionToSql<T> SelectParser(Expression expression, Expression expressionBody, params Type[] ary)
        {
            this._sqlBuilder.Clear();
            this._sqlBuilder.IsSingleTable = false;

            foreach (var item in ary)
            {
                string tableName = item.Name;
                this._sqlBuilder.SetTableAlias(tableName);
            }

            string sql = "select {0}\nfrom " + typeof(T).Name + " " + this._sqlBuilder.GetTableAlias(typeof(T).Name);

            if (expression == null)
            {
                this._sqlBuilder.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expressionBody, this._sqlBuilder);
                this._sqlBuilder.AppendFormat(sql, this._sqlBuilder.SelectFieldsStr);
            }

            return this;
        }
        public ExpressionToSql<T> Select(Expression<Func<T, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2>(Expression<Func<T, T2, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }
        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }


        private ExpressionToSql<T> JoinParser<T2>(Expression<Func<T, T2, bool>> expression, string leftOrRightJoin = "")
        {
            string joinTableName = typeof(T2).Name;
            this._sqlBuilder.SetTableAlias(joinTableName);
            this._sqlBuilder.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + this._sqlBuilder.GetTableAlias(joinTableName));
            Expression2SqlProvider.Join(expression.Body, this._sqlBuilder);
            return this;
        }
        private ExpressionToSql<T> JoinParser2<T2, T3>(Expression<Func<T2, T3, bool>> expression, string leftOrRightJoin = "")
        {
            string joinTableName = typeof(T3).Name;
            this._sqlBuilder.SetTableAlias(joinTableName);
            this._sqlBuilder.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + this._sqlBuilder.GetTableAlias(joinTableName));
            Expression2SqlProvider.Join(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Join<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression);
        }
        public ExpressionToSql<T> Join<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression);
        }

        public ExpressionToSql<T> InnerJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "inner ");
        }
        public ExpressionToSql<T> InnerJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "inner ");
        }

        public ExpressionToSql<T> LeftJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "left ");
        }
        public ExpressionToSql<T> LeftJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "left ");
        }

        public ExpressionToSql<T> RightJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "right ");
        }
        public ExpressionToSql<T> RightJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "right ");
        }

        public ExpressionToSql<T> FullJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "full ");
        }
        public ExpressionToSql<T> FullJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "full ");
        }

        public ExpressionToSql<T> Where(Expression<Func<T, bool>> expression)
        {
            this._sqlBuilder += "\nwhere";
            Expression2SqlProvider.Where(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> GroupBy(Expression<Func<T, object>> expression)
        {
            this._sqlBuilder += "\ngroup by ";
            Expression2SqlProvider.GroupBy(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> OrderBy(Expression<Func<T, object>> expression)
        {
            this._sqlBuilder += "\norder by ";
            Expression2SqlProvider.OrderBy(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Max(Expression<Func<T, object>> expression)
        {
            this._sqlBuilder.Clear();
            Expression2SqlProvider.Max(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Min(Expression<Func<T, object>> expression)
        {
            this._sqlBuilder.Clear();
            Expression2SqlProvider.Min(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Avg(Expression<Func<T, object>> expression)
        {
            this._sqlBuilder.Clear();
            Expression2SqlProvider.Avg(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Count(Expression<Func<T, object>> expression = null)
        {
            this._sqlBuilder.Clear();
            if (expression == null)
            {
                string tableName = typeof(T).Name;

                this._sqlBuilder.SetTableAlias(tableName);
                string tableAlias = this._sqlBuilder.GetTableAlias(tableName);

                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableName += " " + tableAlias;
                }
                this._sqlBuilder.AppendFormat("select count(*) from {0}", tableName);
            }
            else
            {
                Expression2SqlProvider.Count(expression.Body, this._sqlBuilder);
            }

            return this;
        }

        public ExpressionToSql<T> Sum(Expression<Func<T, object>> expression)
        {
            this._sqlBuilder.Clear();
            Expression2SqlProvider.Sum(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Insert(Expression<Func<object>> expression)
        {
            this._sqlBuilder.Clear();
            this._sqlBuilder.IsSingleTable = true;
            this._sqlBuilder += "insert into " + typeof(T).Name;
            Expression2SqlProvider.Insert(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Delete()
        {
            this._sqlBuilder.Clear();
            this._sqlBuilder.IsSingleTable = true;
            string tableName = typeof(T).Name;
            this._sqlBuilder.SetTableAlias(tableName);
            this._sqlBuilder += "delete " + tableName;
            return this;
        }

        public ExpressionToSql<T> Update(Expression<Func<object>> expression)
        {
            this._sqlBuilder.Clear();
            this._sqlBuilder.IsSingleTable = true;
            this._sqlBuilder += "update " + typeof(T).Name + " set ";
            Expression2SqlProvider.Update(expression.Body, this._sqlBuilder);
            return this;
        }
    }
}
