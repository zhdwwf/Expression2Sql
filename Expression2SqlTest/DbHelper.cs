using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Expression2SqlTest
{
    class DbHelper
    {
        public static int ExecuteNonQuery(string sql)
        {
            return 0;
        }

        public static object ExecuteScalar(string sql)
        {
            return null;
        }

        public static DataRow ExecuteDataRow(string sql, Dictionary<string, object> DbParams = null)
        {
            DataTable dt = ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public static DataTable ExecuteDataTable(string sql, Dictionary<string, object> DbParams = null)
        {
            return new DataTable();
        }
    }
}
