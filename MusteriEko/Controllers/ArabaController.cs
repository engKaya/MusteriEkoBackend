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
using MusteriEko.Models.Repository;

namespace MusteriEko.Controllers
{
    public class ArabaController : ApiController
    {

        static ArabaRepo ARepo = new ArabaRepo();

        public HttpResponseMessage GetCarBrands()
        {
            DataTable dataTable = ARepo.GetCarBrands();
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }
        [HttpPost]
        public HttpResponseMessage GetCarGoogleId(Araba araba)
        {
            DataTable dataTable = ARepo.GetCarGoogleId(araba);
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }


        [HttpDelete]
        public string RemoveCar(Araba araba)
        {
            var res = ARepo.DeleteCar(araba);
            return res;
        }

        [HttpPost]
        public HttpResponseMessage FindCars(Musteri musteri)
        {
            DataTable dataTable = ARepo.GetCars(musteri);
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string AddCar(Araba araba)
        {
            var res = ARepo.AddCar(araba);
            return res;
        }

        [HttpPut]
        
        public string UpdateCar(Araba araba)
        {
            var res = ARepo.UpdateCar(araba);
            return res;
        }
    }
}