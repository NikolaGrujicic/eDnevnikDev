﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnikDev.Models;

namespace eDnevnikDev.Controllers
{
    public class ProfesoriController : Controller
    {
        ApplicationDbContext _context;

        public ProfesoriController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Profesori
        public ActionResult Index()
        {
            IEnumerable<Profesor> ListaProfesora = _context.Profesori.ToList();
            return View(ListaProfesora);
        }
        public ActionResult Dodaj()
        {
            return View();
        }
    }
}