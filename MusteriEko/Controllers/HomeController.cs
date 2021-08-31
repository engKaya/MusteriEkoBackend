using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusteriEko.Models;
using System.Data;

namespace MusteriEko.Controllers
{
    public class HomeController : Controller
    {
        //static MusteriRepo repo = new MusteriRepo();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Customer()
        {

            

           // DataTable musteriler = repo.GetAllComplaints();

            ViewBag.Title = "Müşteri Şikayetleri";
            return View();
        }
    }
}
