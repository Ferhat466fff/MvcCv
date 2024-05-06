using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositores;
using MvcCv.Models.Entity;
using System.Web.Security;

namespace MvcCv.Controllers
{       [AllowAnonymous]//Siteye Erişime izin veriyoruz Global.asax işlem yaptık ve burayı muhaf tuttuk.
    public class LoginController : Controller
    {//Admin

        DbCvEntities db = new DbCvEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            var values = db.Tbl_Admin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);//Veri tabındakiyle kulllanıcının girmiş olduğu bilgiler tutarlıysa 
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            else
            {   //çerez-->bilgilerin saklanılan yeri kullancıı adı veya sifreyi hafızada tutuyorda ubiste oldugu gibi.
                FormsAuthentication.SetAuthCookie(values.KullaniciAdi, false);//kimlik doğrulama başarılı olursa cookie(çerez) yerletirir oturum acık olduğu sürece saklanır.false-->çerez kalıcı değidir
                Session["KullaniciAdi"] = values.KullaniciAdi;//otorum boyunca Kullanıcının adını ve soyadını tutacak.
                Session["Resim"] = values.Resim;
                return RedirectToAction("Index", "Sertifika");//oturum dogru acılırsa teacherkursun indexine atacak
            }

            /* web confinnge bunu tanımladık-->                <authentication mode="Forms">
		       sisteme istenmeyen kullanıcı giris yapmaya       <forms loginUrl="/Login/Index/"></forms>
	            giris yapmaya calısırsa tekrar login gonder diyor /authentication>*/
        }

            public ActionResult LogOut()
            {
                FormsAuthentication.SignOut();
                Session.Abandon();//Terk tmek
                return RedirectToAction("Index", "Login");
            }









        
    }
}