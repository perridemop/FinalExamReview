﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ScheduleController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Schedule
        public ActionResult Index(int? year)
        {
            if(year == null)
            {
                year = DateTime.Now.Year;
            }
            var games = db.FootballSchedules.Where(s => s.Season == year.Value);
            return View(games);
        }

    }
}
