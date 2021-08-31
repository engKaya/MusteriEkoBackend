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
    public class MusteriRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MusteriEko"].ToString();
            conn = new SqlConnection(constr);
        }

        public DataTable GetAllComplaints()
        {
            connection();
            conn.Open();

            DataTable datatable = new DataTable();
            
            cmd = new SqlCommand("GetComplaints", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }
            conn.Close();
            return datatable;
        }

        
        public string AddComplaint(Musteri musteri)
        {
            connection();
            conn.Open();
            cmd = new SqlCommand("InsertMusteri", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriIsim", musteri.MusteriIsim);
            cmd.Parameters.AddWithValue("@MusteriSoyIsim", musteri.MusteriSoyIsim);
            cmd.Parameters.AddWithValue("@MusteriTel", musteri.MusteriTel);
            cmd.Parameters.AddWithValue("@MusteriSehir", musteri.MusteriSehir);
            cmd.Parameters.AddWithValue("@MusteriIlce", musteri.MusteriIlce);
            cmd.Parameters.AddWithValue("@MusteriAdres", musteri.MusteriAdres);
            cmd.Parameters.AddWithValue("@MusteriMail", musteri.MusteriMail);
            cmd.Parameters.AddWithValue("@MusteriSikayet", musteri.MusteriSikayet);


            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
                return "Şikayet Eklendi";
            else
                return "Şikayet Eklenemedi";
        }

        public string UpdateComplaint (Musteri musteri)
        {
            connection();
            conn.Open();
            cmd = new SqlCommand("UpdateComplaint", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);
            cmd.Parameters.AddWithValue("@MusteriIsim", musteri.MusteriIsim);
            cmd.Parameters.AddWithValue("@MusteriSoyIsim", musteri.MusteriSoyIsim);
            cmd.Parameters.AddWithValue("@MusteriTel", musteri.MusteriTel);
            cmd.Parameters.AddWithValue("@MusteriSehir", musteri.MusteriSehir);
            cmd.Parameters.AddWithValue("@MusteriIlce", musteri.MusteriIlce);
            cmd.Parameters.AddWithValue("@MusteriAdres", musteri.MusteriAdres);
            cmd.Parameters.AddWithValue("@MusteriMail", musteri.MusteriMail);
            cmd.Parameters.AddWithValue("@MusteriSikayet", musteri.MusteriSikayet);


            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
                return "Şikayet Güncellendi";
            else
                return "Şikayet Güncellenemedi";
        }

        public string DeleteComplaint(Musteri musteri)
        {
            cmd = new SqlCommand("DeleteComplaint", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);

            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                conn.Close();
                return "Şikayet Silindi";
            }
            else
            {
                conn.Close();
                return "Şikayet Silinemedi";
            }
        }

        public DataTable PostFindComplaint(Musteri musteri)
        {
            connection();
            conn.Open();

            DataTable datatable = new DataTable();

            cmd = new SqlCommand("FindComplaint", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriIsim", musteri.MusteriIsim);
            cmd.Parameters.AddWithValue("@MusteriSoyIsim", musteri.MusteriSoyIsim);
            cmd.Parameters.AddWithValue("@MusteriTel", musteri.MusteriTel);


            using (SqlDataReader data = cmd.ExecuteReader())
            {
                datatable.Load(data);
            }

            conn.Close();
            return datatable;
        }
        public DataTable FindComplaintById(Musteri musteri)
        {

            connection();
            conn.Open();
            string query = @"SELECT * FROM dbo.Musteri where MusteriId = "+musteri.MusteriId;
            DataTable datatable = new DataTable();
            cmd = new SqlCommand(query, conn);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            data.Fill(datatable);
            conn.Close();
            return datatable;
        }

    }
}