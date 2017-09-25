﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using eDnevnikDev.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eDnevnikDev.Models;
using System.Data.Entity;
using Moq;
using System.Web.Mvc;
using eDnevnikDev.ViewModel;
using eDnevnikDev.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using eDnevnikDev.Tests.helpers;

namespace eDnevnikDev.Tests.Controllers
{
    [TestClass]
   public class OdeljenjeControllerTest
    {
        //DONE
        [TestMethod]
        public void OdeljenjeController_Index()
        {
            var controller = new OdeljenjeController();
            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;

            Assert.AreEqual(result, viewResult);
        }
        //DONE
        [TestMethod]
        public void PregledKreiranihTest()
        {
            var controller = new OdeljenjeController();
            var result = controller.PregledKreiranih();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.AreEqual(result, viewResult);
        }

        //DONE
        [TestMethod]
        public void OdeljenjeController_OdeljenjeUcenici()
        {
            byte razred = 1;
            int oznakaOdeljenje = 1;
            int status = 1;
            var statusi = new List<Status>()
            {
                new Status() { StatusId=1,Opis="Arhivirano"},
                new Status() {StatusId=2,Opis="U toku" },
                new Status() {StatusId=3,Opis="Kreirano" }
            }.AsQueryable();

            var listaUce = new List<Ucenik>()
            {
                new Ucenik()
                {
                Adresa = "Adresa1",
                BrojTelefonaRoditelja = "064111222",
                DatumRodjenja = DateTime.Now,
                Ime = "Firas",
                Prezime = "Aburas",
                ImeMajke = "Mama",
                PrezimeMajke = "PrezimeMame",
                ImeOca = "Tata",
                PrezimeOca = "PrezimeTate",
                JedinstveniBroj = "1",
                JMBG = "1234567891012",
                MestoPrebivalista = "Beograd",
                MestoRodjenja = new Grad(),
                MestoRodjenjaId = 1,
                Odeljenje = new Odeljenje(),
                OdeljenjeId = oznakaOdeljenje,
                Razred = razred,
                Smer = new Smer(),
                SmerID = 1,
                UcenikID = 1,
                Vanredan = false },

                new Ucenik()
                { Adresa = "Adresa1",
                BrojTelefonaRoditelja = "064111222",
                DatumRodjenja = DateTime.Now,
                Ime = "Firas",
                Prezime = "Aburas",
                ImeMajke = "Mama",
                PrezimeMajke = "PrezimeMame",
                ImeOca = "Tata",
                PrezimeOca = "PrezimeTate",
                JedinstveniBroj = "1",
                JMBG = "1234567891012",
                MestoPrebivalista = "Beograd",
                MestoRodjenja = new Grad(),
                MestoRodjenjaId = 1,
                Odeljenje = new Odeljenje(),
                OdeljenjeId = oznakaOdeljenje,
                Razred = razred,
                Smer = new Smer(),
                SmerID = 1,
                UcenikID = 2,
                Vanredan = false }
            }.AsQueryable();
            var odeljenja = new List<Odeljenje>()
            {
                new Odeljenje() {Id=1,Oznaka=new Oznaka(),OznakaID=1,PocetakSkolskeGodine=2017,KrajSkolskeGodine=2018,Razred=1,Ucenici=listaUce.ToList(),Status=new Status(),StatusID=1 },
                new Odeljenje() {Id=2,Oznaka=new Oznaka(),OznakaID=6,PocetakSkolskeGodine=2018,KrajSkolskeGodine=2019,Razred=3,Ucenici=listaUce.ToList(),Status=new Status(),StatusID=3 },
                new Odeljenje() {Id=3,Oznaka=new Oznaka(),OznakaID=3,PocetakSkolskeGodine=2017,KrajSkolskeGodine=2018,Razred=4,Ucenici=listaUce.ToList(),Status=new Status(),StatusID=2 },

            }.AsQueryable();

            var mockContext = new Mock<ApplicationDbContext>();

            var mockSetUcenik = new Mock<DbSet<Ucenik>>();
            mockSetUcenik.As<IQueryable<Ucenik>>().Setup(m => m.Provider).Returns(listaUce.Provider);
            mockSetUcenik.As<IQueryable<Ucenik>>().Setup(m => m.Expression).Returns(listaUce.Expression);
            mockSetUcenik.As<IQueryable<Ucenik>>().Setup(m => m.ElementType).Returns(listaUce.ElementType);
            mockSetUcenik.As<IQueryable<Ucenik>>().Setup(m => m.GetEnumerator()).Returns(listaUce.GetEnumerator());
            foreach (var item in listaUce)
                mockSetUcenik.Setup(p => p.Add(item));
            mockContext.Setup(p => p.Ucenici).Returns(mockSetUcenik.Object);

            var mockSetStatus = new Mock<DbSet<Status>>();
            mockSetStatus.As<IQueryable<Status>>().Setup(m => m.Provider).Returns(statusi.Provider);
            mockSetStatus.As<IQueryable<Status>>().Setup(m => m.Expression).Returns(statusi.Expression);
            mockSetStatus.As<IQueryable<Status>>().Setup(m => m.ElementType).Returns(statusi.ElementType);
            mockSetStatus.As<IQueryable<Status>>().Setup(m => m.GetEnumerator()).Returns(statusi.GetEnumerator());

            foreach (var item in statusi)
                mockSetStatus.Setup(p => p.Add(item));
            mockContext.Setup(p => p.Statusi).Returns(mockSetStatus.Object);

            var mockSetOdeljenje = new Mock<DbSet<Odeljenje>>();
            mockSetOdeljenje.As<IQueryable<Odeljenje>>().Setup(m => m.Provider).Returns(odeljenja.Provider);
            mockSetOdeljenje.As<IQueryable<Odeljenje>>().Setup(m => m.Expression).Returns(odeljenja.Expression);
            mockSetOdeljenje.As<IQueryable<Odeljenje>>().Setup(m => m.ElementType).Returns(odeljenja.ElementType);
            mockSetOdeljenje.As<IQueryable<Odeljenje>>().Setup(m => m.GetEnumerator()).Returns(odeljenja.GetEnumerator());
            foreach (var item in odeljenja)
                mockSetOdeljenje.Setup(p => p.Add(item));
            mockContext.Setup(p => p.Odeljenja).Returns(mockSetOdeljenje.Object);

            mockSetOdeljenje.Setup(x => x.Include("Status")).Returns(mockSetOdeljenje.Object);

            var odeljenjeController = new OdeljenjeController(mockContext.Object);
            var result = odeljenjeController.OdeljenjeUcenici(razred, oznakaOdeljenje, status) as JsonResult;


            Assert.IsNotNull(result);
            Assert.IsTrue(result.JsonRequestBehavior == JsonRequestBehavior.AllowGet);

            string jsonString = JsonConvert.SerializeObject(result.Data);
            System.Diagnostics.Debug.WriteLine(jsonString);

            var jsonArray = JArray.Parse(Helper.checkJsonJArray(jsonString));
            foreach (JObject item in jsonArray)
            {
                var ucenik = item.GetValue("Ucenici");
                foreach (JObject itemInner in ucenik)
                {
                    string id = itemInner["ID"].ToString();
                    string Ime = itemInner["Ime"].ToString();
                    string Prezime = itemInner["Prezime"].ToString();


                    Ucenik temp = listaUce.FirstOrDefault(x => x.UcenikID == int.Parse(id));
                    Assert.AreEqual<string>(id, temp.UcenikID.ToString());
                    Assert.AreEqual<string>(Ime, temp.Ime.ToString());
                    Assert.AreEqual<string>(Prezime, temp.Prezime.ToString());
                }
            }
            Assert.AreEqual<int>(jsonArray.First.Count(), 2);

        }
        //DONE
        [TestMethod]
        public void OdeljenjeController_OdeljenjeTrajanje()
        {
            int razred =4 ;


            var oznake = new List<Oznaka>()
            {
                new Oznaka() {OznakaId=1 },
                new Oznaka() {OznakaId=2 },
                new Oznaka() {OznakaId=3 },
                new Oznaka() {OznakaId=4 },
                new Oznaka() {OznakaId=5 },
                new Oznaka() {OznakaId=6 },
                new Oznaka() {OznakaId=7 },
            }.AsQueryable();

            var oznake1 = new List<Oznaka>()
            {
                new Oznaka() {OznakaId=1 },
                new Oznaka() {OznakaId=2 },
                new Oznaka() {OznakaId=3 },
                new Oznaka() {OznakaId=4 },
                new Oznaka() {OznakaId=5 },
                new Oznaka() {OznakaId=6 }
            }.AsQueryable();

            var smerovi = new List<Smer>()
            {
                new Smer() {SmerID=1, NazivSmera="Veterinarski tehnicar", Trajanje=4, Oznake=oznake1.ToList() },
                new Smer() {SmerID=2, NazivSmera="Poljoprivredni tehnicar", Trajanje=4, Oznake=oznake1.ToList() },
                new Smer() {SmerID=3, NazivSmera="Mesar", Trajanje=3, Oznake=oznake.ToList() }
            }.AsQueryable();


            var mockContext = new Mock<ApplicationDbContext>();

            var mockSetOznaka = new Mock<DbSet<Oznaka>>();
            mockSetOznaka.As<IQueryable<Oznaka>>().Setup(m => m.Provider).Returns(oznake.Provider);
            mockSetOznaka.As<IQueryable<Oznaka>>().Setup(m => m.Expression).Returns(oznake.Expression);
            mockSetOznaka.As<IQueryable<Oznaka>>().Setup(m => m.ElementType).Returns(oznake.ElementType);
            mockSetOznaka.As<IQueryable<Oznaka>>().Setup(m => m.GetEnumerator()).Returns(oznake.GetEnumerator());

            foreach (var item in oznake)
                mockSetOznaka.Setup(p => p.Add(item));

            mockContext.Setup(p => p.Oznake).Returns(mockSetOznaka.Object);

            var mockSetSmer = new Mock<DbSet<Smer>>();
            mockSetSmer.As<IQueryable<Smer>>().Setup(m => m.Provider).Returns(smerovi.Provider);
            mockSetSmer.As<IQueryable<Smer>>().Setup(m => m.Expression).Returns(smerovi.Expression);
            mockSetSmer.As<IQueryable<Smer>>().Setup(m => m.ElementType).Returns(smerovi.ElementType);
            mockSetSmer.As<IQueryable<Smer>>().Setup(m => m.GetEnumerator()).Returns(smerovi.GetEnumerator());

            foreach (var item in smerovi)
                mockSetSmer.Setup(p => p.Add(item));

            mockContext.Setup(p => p.Smerovi).Returns(mockSetSmer.Object);

            var odeljenjeController = new OdeljenjeController(mockContext.Object);
            var rezultat = odeljenjeController.OdeljenjeTrajanje(razred) as JsonResult;

            //Assert
            Assert.IsNotNull(rezultat);
            Assert.IsTrue(rezultat.JsonRequestBehavior == JsonRequestBehavior.AllowGet);

            string jsonString = JsonConvert.SerializeObject(rezultat.Data);
            System.Diagnostics.Debug.WriteLine(jsonString);

            var jsonArray= JArray.Parse(Helper.checkJsonJArray(jsonString));

            foreach (JObject item in jsonArray)
            {
                string oznaka = item["Oznaka"].ToString();

                Oznaka temp = oznake.FirstOrDefault(o => o.OznakaId == int.Parse(oznaka));
                Assert.AreEqual<string>(oznaka, temp.OznakaId.ToString());
            }

            Assert.AreEqual<int>(jsonArray.Count(), 6);
        }
    }

}
