using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02B_ADO_Stored_Procedures
{
    public class DeleteQuery
    {
        public void DeleteGrant(string grantId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GrantDelete";

                cmd.Parameters.AddWithValue("@GrantId", grantId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
