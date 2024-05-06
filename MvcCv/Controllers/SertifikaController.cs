using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;


namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {//Admin
        SertifikalarımRepository db = new SertifikalarımRepository();

        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.

        //Sertifika Listeleme
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        //Sertifika EKle
        [HttpGet]
        public ActionResult AddSertifika()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddSertifika(Tbl_Sertifikalarim serifika)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSertifika");
            }
            db.TAdd(serifika);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteSertifika(Tbl_Sertifikalarim k)
        {
            
            var values = db.Find(x => x.ID == k.ID);
            db.TDelete(values);
            return RedirectToAction("Index");
        }

        //Sertifika Güncelleme
        [HttpGet]
        public ActionResult UpdateSertifika(int id)//Tarihe Tıklandığında Güncelleme Sayfası Açılacak.
        {
            var values = db.Find(x => x.ID==id);
            ViewBag.dgr = id;  //Sertifika Silmeyi Güncelleme Sayfasında Yapıyoruz.
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSertifika(Tbl_Sertifikalarim k)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateSertifika");
            }
            var values = db.Find(x => x.ID == k.ID);
            values.ID = k.ID;
            values.Aciklama = k.Aciklama;
            values.Tarih = k.Tarih;
            db.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}