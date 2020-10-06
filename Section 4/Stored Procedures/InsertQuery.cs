using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02B_ADO_Stored_Procedures
{
    public class InsertQuery
    {
        public void InsertGrant(string grantId, string grantName, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GrantInsert";

                cmd.Parameters.AddWithValue("@GrantId", grantId);
                cmd.Parameters.AddWithValue("@GrantName", grantName);
                cmd.Parameters.AddWithValue("@Amount", amount);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
