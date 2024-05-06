using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositores;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {//Admin
       
        YeteneklerRepository db = new YeteneklerRepository();//Yetenekleri Kullanacagız.
        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.

        //Yetenek Listeleme
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        //Yetenek Ekleme
        [HttpGet]
        public ActionResult AddYetenek()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddYetenek(Tbl_Yetenekler k)
        {
            if(!ModelState.IsValid)
            {
                return View("AddYetenek");
            }
            db.TAdd(k);//TAdd Çağırdık -->GenericRepositoryden
            return RedirectToAction("Index");
        }
        //Yetenek Silme
        public ActionResult DeleteYetenek(int id)
        {
            Tbl_Yetenekler yetenek = db.Find(x => x.ID == id);//Silmek İçin Id Gerekli Find ile Aldık
            db.TDelete(yetenek);//Tdelete Çağırdık -->GenericRepositoryden
            return RedirectToAction("Index");
        }

        //Yetenek Güncelleme
        [HttpGet]
        public ActionResult UpdateYetenek(int id)
        {
            Tbl_Yetenekler yetenek = db.Find(x => x.ID == id);
            return View(yetenek);

        }
        [HttpPost]
        public ActionResult UpdateYetenek(Tbl_Yetenekler k)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateYetenek");
            }
            Tbl_Yetenekler yetenek = db.Find(x => x.ID == k.ID);
            yetenek.Yetenek = k.Yetenek;
            yetenek.Oran = k.Oran;
            db.TUpdate(yetenek);
            return RedirectToAction("Index");
        }


    }
}