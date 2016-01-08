using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Expression2SqlTest
{
    class Mapping
    {
        public static T ToEntity<T>(DataRow dr)
        {
            return default(T);
        }

        public static List<T> ToListEntity<T>(DataTable dt)
        {
            return default(List<T>);
        }
    }
}
