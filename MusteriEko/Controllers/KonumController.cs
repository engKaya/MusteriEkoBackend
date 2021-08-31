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
    public class KonumController : ApiController
    {
        KonumRepo kRepo = new KonumRepo();

        public HttpResponseMessage GetCity()
        {
            DataTable datatable = kRepo.GetAllCities();
            return Request.CreateResponse(HttpStatusCode.OK, datatable);
        }
        [HttpPost]
        public HttpResponseMessage GetTowns(Sehir sehir)
        {
            DataTable datatable = kRepo.GetTowns(sehir);
            return Request.CreateResponse(HttpStatusCode.OK, datatable);
        }
    }
}