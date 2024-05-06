using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DeneyimlerController : Controller
    {//Admin
        DeneyimRepository db = new DeneyimRepository();

       // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.




        //Deneyim Listeleme
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }

        //Deneyim Ekleme
        [HttpGet]
        public ActionResult AddDeneyimler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDeneyimler(Tbl_Deneyimlerim deneyim)
        {
            if(!ModelState.IsValid)
            {
                return View("AddDeneyimler");
            }
            db.TAdd(deneyim);
            return RedirectToAction("Index");
        }

        //Deneyim Silme
        public ActionResult DeleteDeneyimler(int id)
        {
            Tbl_Deneyimlerim deneyim = db.Find(x => x.ID == id); //TblDeneyimler Tablomuuzn Adı Find İle Id'ler Eşitse Silsin.
            db.TDelete(deneyim);
            return RedirectToAction("Index");
        }

        //Deneyim Güncelleme
        [HttpGet]
        public ActionResult UpdateDeneyimler(int id)
        {
            Tbl_Deneyimlerim t= db.Find(x => x.ID == id); //GenericRepository Find Methodu Yazmıştık Bu sayede Verileri Taşıdık
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateDeneyimler(Tbl_Deneyimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateDeneyimler");
            }
            Tbl_Deneyimlerim t = db.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            db.TUpdate(t);
            return RedirectToAction("Index");
        }








    }
}