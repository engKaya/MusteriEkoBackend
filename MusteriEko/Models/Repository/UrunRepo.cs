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
    public class UrunRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MusteriEko"].ToString();
            conn = new SqlConnection(constr);
            this.conn.Open();
        }

        public DataTable GetProducts(Musteri musteri)
        {
            connection();

            DataTable datatable = new DataTable();

            this.cmd = new SqlCommand("getCustomerItems", this.conn);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);

            using (SqlDataReader data = this.cmd.ExecuteReader())
            {
                datatable.Load(data);
            }

            conn.Close();
            return datatable;
        }

        public DataTable GetProductBrands()
        {
            connection();

            DataTable datatable = new DataTable();

            this.cmd = new SqlCommand("GetProductBrands", conn);
            this.cmd.CommandType = CommandType.StoredProcedure;


            using (SqlDataReader data = this.cmd.ExecuteReader())
            {
                datatable.Load(data);
            }

            conn.Close();
            return datatable;
        }
        public string AddProduct(Urun urun)
        {
            connection();
            
            this.cmd = new SqlCommand("AddProduct", conn);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@MusteriId", urun.MusteriId);
            this.cmd.Parameters.AddWithValue("@MarkaId", urun.MarkaId);
            this.cmd.Parameters.AddWithValue("@Model", urun.Model);
            this.cmd.Parameters.AddWithValue("@RAM", urun.RAM);
            this.cmd.Parameters.AddWithValue("@CPU", urun.CPU);
            this.cmd.Parameters.AddWithValue("@HardDrive", urun.HardDrive);

            int i = cmd.ExecuteNonQuery();
            this.conn.Close();
            if (i >= 1)
                return "Ürün Eklendi";
            else
                return "Ürün Eklenemedi";
        }
        public string DeleteProduct(Urun urun)
        {
            connection();
            this.cmd = new SqlCommand("deleteProduct", conn);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@UrunId", urun.UrunId);

            int i = this.cmd.ExecuteNonQuery();
            this.conn.Close();
            if (i >= 1)
                return "Ürün Silindi";
            else
                return "Ürün Silinemedi";
        }

    }
}