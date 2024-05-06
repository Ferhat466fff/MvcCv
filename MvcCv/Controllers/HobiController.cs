using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {

        HobilerimRepository db = new HobilerimRepository();
        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.


        //Hobi Listeleme-Güncelleme
        [HttpGet]
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim hobi)
        {
            var values = db.Find(x => x.ID == 1);
            values.Aciklama1 = hobi.Aciklama1;
            values.Aciklama2 = hobi.Aciklama2;
            db.TUpdate(values);
            return RedirectToAction("Index");
        }

    }
}