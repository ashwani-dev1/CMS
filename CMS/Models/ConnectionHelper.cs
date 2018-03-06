using CMSDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection(string conn)
        {
            return new DbConnectionFactory(conn);
        }
    }
}
