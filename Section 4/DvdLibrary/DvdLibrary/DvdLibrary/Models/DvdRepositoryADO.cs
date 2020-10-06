using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Create(Dvd newDvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdInsert";

                cmd.Parameters.AddWithValue("@DvdId", newDvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", newDvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", newDvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", newDvd.Director);
                cmd.Parameters.AddWithValue("@Rating", newDvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", newDvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DvdDelete";

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dvd Get(int dvdId)
        {
            Dvd dvd = new Dvd();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdSelectById";

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
            
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {                     
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                    
                        if (dr["Notes"] != DBNull.Value)
                            dvd.Notes = dr["Notes"].ToString();

                        if (dr["Rating"] != DBNull.Value)
                            dvd.Rating = dr["Rating"].ToString();

                        if (dr["Director"] != DBNull.Value)
                            dvd.Director = dr["Director"].ToString();
                        dvd.DvdId = (int)dr["DvdId"];
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DvdSelectAll";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        if (dr["Rating"] != DBNull.Value)
                            currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Director"] != DBNull.Value)
                            currentRow.Director = dr["Director"].ToString();

                        currentRow.DvdId = (int)dr["DvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }

            return dvds;
        }
        public void Update(Dvd updatedDvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdUpdate";

                cmd.Parameters.AddWithValue("@DvdId", updatedDvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", updatedDvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", updatedDvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", updatedDvd.Director);
                cmd.Parameters.AddWithValue("@Rating", updatedDvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", updatedDvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Dvd> GetbyTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdSelectByTitle";

                cmd.Parameters.AddWithValue("@Title", title);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        if (dr["Rating"] != DBNull.Value)
                            currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Director"] != DBNull.Value)
                            currentRow.Director = dr["Director"].ToString();

                        currentRow.DvdId = (int)dr["DvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
        public List<Dvd> GetbyYear(int releaseYear)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdSelectByYear";

                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        if (dr["Rating"] != DBNull.Value)
                            currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Director"] != DBNull.Value)
                            currentRow.Director = dr["Director"].ToString();

                        currentRow.DvdId = (int)dr["DvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetbyDirector(string director)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdSelectByDirector";

                cmd.Parameters.AddWithValue("@Director", director);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        if (dr["Rating"] != DBNull.Value)
                            currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Director"] != DBNull.Value)
                            currentRow.Director = dr["Director"].ToString();

                        currentRow.DvdId = (int)dr["DvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetbyRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DvdSelectByRating";

                cmd.Parameters.AddWithValue("@Rating", rating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        if (dr["Rating"] != DBNull.Value)
                            currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Director"] != DBNull.Value)
                            currentRow.Director = dr["Director"].ToString();

                        currentRow.DvdId = (int)dr["DvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
    }
}