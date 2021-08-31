using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using MusteriEko.Models;

namespace MusteriEko.Controllers
{
    public class UrunController : ApiController
    {
        //static UrunRepo URepo = new UrunRepo();

        public HttpResponseMessage GetProductBrands()
        {
            UrunRepo URepo = new UrunRepo();
            DataTable dataTable = URepo.GetProductBrands();
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        [HttpPost]
        public HttpResponseMessage FindProducts(Musteri musteri)
        {
            UrunRepo URepo = new UrunRepo();
            DataTable dataTable = URepo.GetProducts(musteri);
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string AddProduct(Urun urun)
        {
            UrunRepo URepo = new UrunRepo();
            var res = URepo.AddProduct(urun);
            return res;
        }

        [HttpDelete]
        public string RemoveProduct(Urun urun)
        {
            UrunRepo URepo = new UrunRepo();
            var res = URepo.DeleteProduct(urun);
            return res;
        }


    }
}