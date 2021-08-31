using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MusteriEko.Models;

namespace MusteriEko.Models
{
    public class KonumRepo
    {

        private SqlConnection conn;
        private SqlCommand cmd;

        private void connection()
        {
            string connstr = ConfigurationManager.ConnectionStrings["MusteriEko"].ToString();
            conn = new SqlConnection(connstr);
        }

        public DataTable GetAllCities()
        {
            connection();
            DataTable datatable = new DataTable();

            cmd = new SqlCommand("GetAllCities", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }
            conn.Close();

            return datatable;
        }

        public DataTable GetTowns(Sehir sehir)
        {
            connection();
            DataTable datatable = new DataTable();

            cmd = new SqlCommand("GetTowns", conn);
            cmd.Parameters.AddWithValue("@SehirId", sehir.SehirId);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }
            conn.Close();

            return datatable;
        }
    }
}