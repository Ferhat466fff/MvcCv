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
    public class AdminController : Controller
    {//Admin
        GenericRepository<Tbl_Admin> db = new GenericRepository<Tbl_Admin>();
        DbCvEntities kb = new DbCvEntities();

        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.


        //İletişim Bilgileri Listeleme
        
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        //Admin Ekleme
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Tbl_Admin p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Resim = "/Image/" + dosyaadi + uzanti;
            }
            kb.Tbl_Admin.Add(p);
            kb.SaveChanges();
            return RedirectToAction("Index");

        }


        //Admin Silme
        public ActionResult DeleteAdmin(int id)
        {
            Tbl_Admin Admin = db.Find(x => x.ID == id); //TblDeneyimler Tablomuuzn Adı Find İle Id'ler Eşitse Silsin.
            db.TDelete(Admin);
            return RedirectToAction("Index");
        }





        //Admin Güncelleme
        [HttpGet]
        public ActionResult UpdateAdminn(int id)
        {
            var values = kb.Tbl_Admin.Find(id); 
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdminn(Tbl_Admin p)
        {
            var value = kb.Tbl_Admin.Find(p.ID);

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Resim = "/Image/" + dosyaadi + uzanti;
            }

            value.KullaniciAdi = p.KullaniciAdi;
            value.Sifre = p.Sifre;
            value.Resim = p.Resim;
            kb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}