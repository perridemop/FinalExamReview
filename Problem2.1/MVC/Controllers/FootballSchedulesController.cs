using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC;
using MVC.Models;

namespace MVC.Controllers
{
    public class FootballSchedulesController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: FootballSchedules
        public ActionResult Index()
        {
            return View(db.FootballSchedules.ToList());
        }

 
    }
}
