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
using System.Linq;
using System.Text;

namespace Expression2Sql
{
    public class SqlBuilder
    {
        private static readonly List<string> S_listEnglishWords = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        private Dictionary<string, string> _dicTableName = new Dictionary<string, string>();
        private Queue<string> _queueEnglishWords = new Queue<string>(S_listEnglishWords);
        private IDbSqlParser _dbSqlParser;
        private StringBuilder _sqlBuilder;

        internal bool IsSingleTable { get; set; }

        internal List<string> SelectFields { get; set; }

        internal string SelectFieldsStr
        {
            get
            {
                return string.Join(",", this.SelectFields);
            }
        }

        internal int Length
        {
            get
            {
                return this._sqlBuilder.Length;
            }
        }

        internal string Sql
        {
            get { return this.ToString(); }
        }

        internal Dictionary<string, object> DbParams { get; private set; }

        internal char this[int index]
        {
            get
            {
                return this._sqlBuilder[index];
            }
        }

        internal SqlBuilder(IDbSqlParser dbSqlParser)
        {
            this.DbParams = new Dictionary<string, object>();
            this._sqlBuilder = new StringBuilder();
            this.SelectFields = new List<string>();
            this._dbSqlParser = dbSqlParser;
        }

        public static SqlBuilder operator +(SqlBuilder sqlBuilder, string sql)
        {
            sqlBuilder._sqlBuilder.Append(sql);
            return sqlBuilder;
        }

        internal void Clear()
        {
            this.SelectFields.Clear();
            this._sqlBuilder.Clear();
            this.DbParams.Clear();
            this._dicTableName.Clear();
            this._queueEnglishWords = new Queue<string>(S_listEnglishWords);
        }

        internal string AddDbParameter(object dbParamValue, bool allowAutoAppend = true)
        {
            string dbParamName = "";
            if (dbParamValue == null || dbParamValue == DBNull.Value)
            {
                if (allowAutoAppend)
                {
                    this._sqlBuilder.Append(" null");
                }
            }
            else
            {
                dbParamName = this._dbSqlParser.DbParamPrefix + "param" + this.DbParams.Count;
                this.DbParams.Add(dbParamName, dbParamValue);
                if (allowAutoAppend)
                {
                    this._sqlBuilder.Append(" " + dbParamName);
                }
            }
            return dbParamName;
        }

        internal bool SetTableAlias(string tableName)
        {
            if (!this._dicTableName.Keys.Contains(tableName))
            {
                this._dicTableName.Add(tableName, this._queueEnglishWords.Dequeue());
                return true;
            }
            return false;
        }

        internal string GetTableAlias(string tableName)
        {
            if (!this.IsSingleTable && this._dicTableName.Keys.Contains(tableName))
            {
                return this._dicTableName[tableName];
            }
            return "";
        }

        public override string ToString()
        {
            return this._sqlBuilder.ToString();
        }

        #region StringBuilder 方法封装
        internal void Insert(int index, string value)
        {
            this._sqlBuilder.Insert(index, value);
        }

        internal void AppendFormat(string format, object arg0)
        {
            this._sqlBuilder.AppendFormat(format, arg0);
        }

        internal void AppendFormat(string format, object arg0, object arg1)
        {
            this._sqlBuilder.AppendFormat(format, arg0, arg1);
        }

        internal void AppendFormat(string format, object arg0, object arg1, object arg2)
        {
            this._sqlBuilder.AppendFormat(format, arg0, arg1, arg2);
        }

        internal void Remove(int startIndex, int length)
        {
            this._sqlBuilder.Remove(startIndex, length);
        }
        #endregion

    }
}