using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;


namespace MvcCv.Controllers
{//UI TARAFI

    [AllowAnonymous]
    public class DefaultController : Controller
    {

        DbCvEntities db = new DbCvEntities();

        //Hakkımda Lisetleme
        public ActionResult Index()
        {
           
            return View();
        }
        //Hakkımda Listeleme
        public PartialViewResult Hakkımda()
        {
            var values = db.Tbl_Hakkimda.ToList();
            return PartialView(values);
        }

        //Deneyim Listeleme
        public PartialViewResult Deneyim()
        {
            var values = db.Tbl_Deneyimlerim.ToList();
            return PartialView(values);
        }
        //Sosyal Medya Listeleme
        public PartialViewResult SosyalMedya()
        {
            //Sosyal Medya True ise Listeleme Yapcak
            var values = db.TblSosyalMedya.Where(x => x.Durum==true).ToList();
            return PartialView(values);
        }

        //Eğitim Listeleme
        public PartialViewResult Egitim()
        {
            var values = db.Tbl_Egitim.ToList();
            return PartialView(values);
        }
        //Yetenek Listeleme
        public PartialViewResult Yetenek()
        {
            var values = db.Tbl_Yetenekler.ToList();
            return PartialView(values);
        }
        //Yetenek Listeleme
        public PartialViewResult Hobi()
        {
            var values = db.Tbl_Hobilerim.ToList();
            return PartialView(values);
        }
        //Sertifika Listeleme
        public PartialViewResult Sertifika()
        {
            var values = db.Tbl_Sertifikalarim.ToList();
            return PartialView(values);
        }

        //Mesaj Gönderme
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbl_iletisim Tbl_iletisim)
        {
            Tbl_iletisim.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_iletisim.Add(Tbl_iletisim);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult SidenavResim()//Resim İçin Açtım
        {
            var values = db.Tbl_Hakkimda.ToList();
            return PartialView(values);
        }




    }
}