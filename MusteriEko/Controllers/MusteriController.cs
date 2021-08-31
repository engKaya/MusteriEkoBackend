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
    public class MusteriController : ApiController
    {

        static MusteriRepo MRepo = new MusteriRepo();

        public HttpResponseMessage GetComplaints()
        {
            DataTable dataTable = MRepo.GetAllComplaints();
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }
        public HttpResponseMessage PostFindById(Musteri musteri)
        {
            DataTable dataTable = MRepo.FindComplaintById(musteri);
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string PostComplaint(Musteri musteri)
        {
            var res = MRepo.AddComplaint(musteri);
            return res;
        }
        [HttpPut]
        public string UpdateComplaint(Musteri musteri)
        {
            var res = MRepo.UpdateComplaint(musteri);
            return res;
        }

        public string DeleteComplaint (Musteri musteri)
        {
            var res = MRepo.DeleteComplaint(musteri);
            return res;
        }

        public HttpResponseMessage FindComplaint(Musteri musteri)
        {
            DataTable dataTable = MRepo.PostFindComplaint(musteri);
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

    }
}