using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MusteriEko.Models;

namespace MusteriEko.Models.Repository
{
    public class ArabaRepo
    {

        private SqlConnection conn;
        private SqlCommand cmd;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MusteriEko"].ToString();
            conn = new SqlConnection(constr);
        }

        public string AddCar(Araba araba)
        {
            connection();
            conn.Open();
            cmd = new SqlCommand("AddCar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriId", araba.MusteriId);
            cmd.Parameters.AddWithValue("@MarkaId", araba.MarkaId);
            cmd.Parameters.AddWithValue("@Model", araba.Model);
            cmd.Parameters.AddWithValue("@Motor", araba.Motor);
            cmd.Parameters.AddWithValue("@Yil", araba.Yil);
            cmd.Parameters.AddWithValue("@ResimUrl", araba.ResimUrl);
            cmd.Parameters.AddWithValue("@b64_encoded", araba.Base64);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
                return "Araba Eklendi";
            else
                return "Araba Eklenemedi";
        }
        public string DeleteCar(Araba araba)
        {
            connection();
            conn.Open();
            cmd = new SqlCommand("DeleteCar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AracId", araba.AracId);

            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
                return "Araç Silindi";
            else
                return "Araç Silinemedi";
        }

        public DataTable GetCars(Musteri musteri)
        {
            connection();
            conn.Open();

            DataTable datatable = new DataTable();

            cmd = new SqlCommand("GetCars", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);

            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }
            conn.Close();

            return datatable;
        }

        public DataTable GetCarGoogleId(Araba araba)
        {
            connection();
            conn.Open();

            DataTable datatable = new DataTable();

            cmd = new SqlCommand("GetGoogleImageId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AracId", araba.AracId);

            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }
            conn.Close();

            return datatable;
        }

        public string UpdateCar(Araba araba)
        {
            connection();
            conn.Open();
            cmd = new SqlCommand("UpdateCar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AracId", araba.AracId);
            cmd.Parameters.AddWithValue("@MarkaId", araba.MarkaId);
            cmd.Parameters.AddWithValue("@Yil", araba.Yil);
            cmd.Parameters.AddWithValue("@Model", araba.Model);
            cmd.Parameters.AddWithValue("@Motor", araba.Motor);
            cmd.Parameters.AddWithValue("@ResimUrl", araba.ResimUrl);
            cmd.Parameters.AddWithValue("@b64_encoded", araba.Base64);


            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
                return "Araç Güncellendi";
            else
                return "Araç Güncellenemedi";
        }
        public DataTable GetCarBrands()
        {
            connection();
            conn.Open();

            DataTable datatable = new DataTable();

            cmd = new SqlCommand("GetCarBrands", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }
            conn.Close();

            return datatable;
        }
    }
}