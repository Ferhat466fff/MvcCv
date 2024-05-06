using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;
using System.IO;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        DbCvEntities kb = new DbCvEntities();
        HakkimdaRepository db = new HakkimdaRepository();
        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.


        //Hobi Listeleme-Güncelleme
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = db.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkimda h)
        {
            var values = db.Find(x => x.ID == 1);
            values.Ad = h.Ad;
            values.Soyad = h.Soyad;
            values.Telefon = h.Telefon;
            values.Adres = h.Adres;
            values.Mail = h.Mail;
            values.Resim = h.Resim;
            values.Aciklama = h.Aciklama;
            db.TUpdate(values);
            return RedirectToAction("Index");
        }

        //Hakkımda Ekleme
        [HttpGet]
        public ActionResult AddHakkimda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHakkimda(Tbl_Hakkimda p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Resim = "/Image/" + dosyaadi + uzanti;
            }
            if (!ModelState.IsValid)//Model Doğrulaması Geçerli Değilse AddEgitim Geri Yolla.
            {
                return View("AddHakkimda");
            }
            kb.Tbl_Hakkimda.Add(p);
            kb.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteHakkimda(int id)
        {
            var values = kb.Tbl_Hakkimda.Find(id);
            kb.Tbl_Hakkimda.Remove(values);
            kb.SaveChanges();
            return RedirectToAction("Index");
        }

        //Hakkimda Güncelleme
        [HttpGet]
        public ActionResult UpdateHakkimda(int id)
        {
            var values = kb.Tbl_Hakkimda.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateHakkimda(Tbl_Hakkimda p)
        {
            var value = kb.Tbl_Hakkimda.Find(p.ID);

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Resim = "/Image/" + dosyaadi + uzanti;
            }

            value.Ad = p.Ad;
            value.Soyad = p.Soyad;
            value.Adres = p.Adres;
            value.Telefon = p.Telefon;
            value.Mail = p.Mail;
            value.Aciklama = p.Aciklama;
            value.Resim = p.Resim;
            kb.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}