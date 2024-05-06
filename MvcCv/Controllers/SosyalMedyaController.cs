using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {//Admin
        GenericRepository<TblSosyalMedya> db = new GenericRepository<TblSosyalMedya>();

        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.

        //Sertifika Listeleme
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        //Sosyal Medya Ekleme(Pop-up)
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya s)
        {
            db.TAdd(s);
            return RedirectToAction("Index");
        }


        //Sosyal Medya Silme(Aktif-Pasif)-->Sil Basınca Pasif olsun.
        public ActionResult DeleteSosyalMedya(int id)
        {
            var values = db.Find(x => x.ID == id);
            values.Durum = false;
            db.TUpdate(values);
            return RedirectToAction("Index");
        }



        //Sosyal Medya Güncelleme
        [HttpGet]
        public ActionResult UpdateSosyalMedya(int id)
        {
            TblSosyalMedya value = db.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSosyalMedya(TblSosyalMedya p)
        {   //TblEgitim Classına-->Required Tanımlaması Yaptık.
            TblSosyalMedya value = db.Find(x => x.ID == p.ID);
            value.Durum = true;
            value.Ad = p.Ad;
            value.Link = p.Link;
            value.Icon = p.Icon;
            db.TUpdate(value);
            return RedirectToAction("Index");
        }


    }
}