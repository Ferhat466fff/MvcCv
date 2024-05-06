using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {//Admin
        iletisimRepository db = new iletisimRepository();

        // GenericRepository Diye Sınıf Açtık Crud İşlemlerini Oradan Yapıyoruz.İstersen Klasik Olarak Ellede Yazabilirdik.


        //İletişim Bilgileri Listeleme
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        //Mesaj Silme
        public ActionResult Deleteiletisim(int id)
        {
            Tbl_iletisim ileti = db.Find(x => x.ID == id); //TblDeneyimler Tablomuuzn Adı Find İle Id'ler Eşitse Silsin.
            db.TDelete(ileti);
            return RedirectToAction("Index");
        }







    }


}