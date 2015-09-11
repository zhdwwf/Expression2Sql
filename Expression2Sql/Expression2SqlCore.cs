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
    public class Expression2SqlCore<T>
    {
        private SqlPack _sqlPack = new SqlPack();

        public string SqlStr
        {
            get
            {
                return this._sqlPack.ToString();
            }
        }
        public Dictionary<string, object> DbParams
        {
            get
            {
                return this._sqlPack.DbParams;
            }
        }

        public void Clear()
        {
            this._sqlPack.Clear();
        }

        private string SelectParser(params Type[] ary)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = false;

            foreach (var item in ary)
            {
                string tableName = item.Name;
                this._sqlPack.SetTableAlias(tableName);
            }

            return "select {0}\nfrom " + typeof(T).Name + " " + this._sqlPack.GetTableAlias(typeof(T).Name);
        }
        public Expression2SqlCore<T> Select(Expression<Func<T, object>> expression = null)
        {
            string sql = SelectParser(typeof(T));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2>(Expression<Func<T, T2, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }
        public Expression2SqlCore<T> Select<T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
        {
            string sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10));

            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }

            return this;
        }

        private Expression2SqlCore<T> JoinParser<T2>(Expression<Func<T, T2, bool>> expression, string leftOrRightJoin = "")
        {
            string joinTableName = typeof(T2).Name;
            this._sqlPack.SetTableAlias(joinTableName);
            this._sqlPack.Sql.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + this._sqlPack.GetTableAlias(joinTableName));
            Expression2SqlProvider.Join(expression.Body, this._sqlPack);
            return this;
        }
        private Expression2SqlCore<T> JoinParser2<T2, T3>(Expression<Func<T2, T3, bool>> expression, string leftOrRightJoin = "")
        {
            string joinTableName = typeof(T3).Name;
            this._sqlPack.SetTableAlias(joinTableName);
            this._sqlPack.Sql.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + this._sqlPack.GetTableAlias(joinTableName));
            Expression2SqlProvider.Join(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> Join<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression);
        }
        public Expression2SqlCore<T> Join<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression);
        }

        public Expression2SqlCore<T> InnerJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "inner ");
        }
        public Expression2SqlCore<T> InnerJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "inner ");
        }

        public Expression2SqlCore<T> LeftJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "left ");
        }
        public Expression2SqlCore<T> LeftJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "left ");
        }

        public Expression2SqlCore<T> RightJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "right ");
        }
        public Expression2SqlCore<T> RightJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "right ");
        }

        public Expression2SqlCore<T> FullJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "full ");
        }
        public Expression2SqlCore<T> FullJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "full ");
        }

        public Expression2SqlCore<T> Where(Expression<Func<T, bool>> expression)
        {
            this._sqlPack += "\nwhere";
            Expression2SqlProvider.Where(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> GroupBy(Expression<Func<T, object>> expression)
        {
            this._sqlPack += "\ngroup by ";
            Expression2SqlProvider.GroupBy(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> OrderBy(Expression<Func<T, object>> expression)
        {
            this._sqlPack += "\norder by ";
            Expression2SqlProvider.OrderBy(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> Max(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            Expression2SqlProvider.Max(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> Min(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            Expression2SqlProvider.Min(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> Avg(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            Expression2SqlProvider.Avg(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> Count(Expression<Func<T, object>> expression = null)
        {
            this._sqlPack.Clear();
            if (expression == null)
            {
                string tableName = typeof(T).Name;

                this._sqlPack.SetTableAlias(tableName);
                string tableAlias = this._sqlPack.GetTableAlias(tableName);

                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableName += " " + tableAlias;
                }
                this._sqlPack.Sql.AppendFormat("select count(*) from {0}", tableName);
            }
            else
            {
                Expression2SqlProvider.Count(expression.Body, this._sqlPack);
            }

            return this;
        }

        public Expression2SqlCore<T> Sum(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            Expression2SqlProvider.Sum(expression.Body, this._sqlPack);
            return this;
        }

        public Expression2SqlCore<T> Delete()
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            string tableName = typeof(T).Name;
            this._sqlPack.SetTableAlias(tableName);
            this._sqlPack += "delete " + tableName;
            return this;
        }

        public Expression2SqlCore<T> Update(Expression<Func<object>> expression = null)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            this._sqlPack += "update " + typeof(T).Name + " set ";
            Expression2SqlProvider.Update(expression.Body, this._sqlPack);
            return this;
        }
    }
}
