﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnikDev.Models;
using eDnevnikDev.ViewModel;

namespace eDnevnikDev.Controllers
{
    public class ProfesoriController : Controller
    {
        ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfesoriController"/> class.
        /// </summary>
        public ProfesoriController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Profesori
        /// <summary>
        /// Uzima se lista profesora iz Baze
        /// </summary>
        /// <returns>Vraca listu u View</returns>
        public ActionResult Index()
        {
            IEnumerable<Profesor> ListaProfesora = _context.Profesori.ToList();
            return View(ListaProfesora);
        }
        /// <summary>
        /// Dodaje se Profesor u Listu Profesora
        /// </summary>
        /// <returns>Vraca novog profesora, <see cref="ProfesorViewModel"/></returns>
        public ActionResult Dodaj()
        {
            var model = new ProfesorViewModel
            {
                Predmeti = _context.Predmeti.ToList()
            };



            return View(model);
        }
    }
}