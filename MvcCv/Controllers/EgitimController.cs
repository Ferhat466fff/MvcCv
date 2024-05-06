using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositores;

namespace MvcCv.Controllers
{
    
    public class EgitimController : Controller
    {//Admin

        GenericRepository<Tbl_Egitim> db = new GenericRepository<Tbl_Egitim>();
        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.


        //Eğitim Listeleme

        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        //Eğitim Ekleme
        [HttpGet]
        public ActionResult AddEgitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEgitim(Tbl_Egitim egitim)
        {   //TblEgitim Classına-->Required Tanımlaması Yaptık.
            if (!ModelState.IsValid)//Model Doğrulaması Geçerli Değilse AddEgitim Geri Yolla.
            {
                return View("AddEgitim");
            }
            db.TAdd(egitim);//TAdd Çağırdık -->GenericRepositoryden
            return RedirectToAction("Index");
        }

        //Eğitim Silme
        public ActionResult DeleteEgitim(int id)
        {
            Tbl_Egitim value = db.Find(x => x.ID == id);
            db.TDelete(value);
            return RedirectToAction("Index");
        }

        //Eğitim Güncelleme
        [HttpGet]
        public ActionResult UpdateEgitim(int id)
        {
            Tbl_Egitim value = db.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEgitim(Tbl_Egitim p)
        {   //TblEgitim Classına-->Required Tanımlaması Yaptık.
            if (!ModelState.IsValid)//Model Doğrulaması Geçerli Değilse AddEgitim Geri Yolla.
            {
                return View("UpdateEgitim");
            }
            Tbl_Egitim value = db.Find(x => x.ID == p.ID);
            value.Baslik = p.Baslik;
            value.AltBaslik = p.AltBaslik;
            value.AltBaslik2 = p.AltBaslik2;
            value.Tarih = p.Tarih;
            value.GNO = p.GNO;
            db.TUpdate(value);
            return RedirectToAction("Index");
        }






    }
}