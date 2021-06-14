using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTrack_OMdbWebAPI.Utilities
{
    public static class DapperContext
    {
        public static string connStr = ConfigurationManager.AppSettings["ConString"];
        public static void ExecuteWithoutReturn(string procname, DynamicParameters dataParams)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(procname, dataParams, commandType: CommandType.StoredProcedure);
            }

        }

        public static T ExecuteReturnScalar<T>(string procname, DynamicParameters dataParams)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                List<T> ts = conn.Query<T>(procname, dataParams, commandType: CommandType.StoredProcedure).ToList();       
                return (T)Convert.ChangeType(conn.QueryFirst<T>(procname, dataParams, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procname, DynamicParameters dataParams)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                return conn.Query<T>(procname, dataParams, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
