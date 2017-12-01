using Blog.DAL.Context;
using Blog.DAL.UnitOfWork;
using Blog.Domain.Core;
using Blog.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Presentation.Controllers
{
    public class UyeController : Controller
    {
        BlogContext ent = new BlogContext();
        UnitOfWork unitofwork = new UnitOfWork(new BlogContext());

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UyeListesi()
        {
            var liste = (from u in ent.Uyeler select new UyeModel { uyeAdSoyad = u.Ad + " " + u.Soyad, email = u.Email }).ToList();


            return Json(liste, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UyeGiris()
        {


            return View();
        }


        [HttpPost]
        public string UyeGiris(string Email, string Sifre)
        {
            Uye uye = unitofwork.Repository<Uye>().Get(u => u.Email == Email && u.Sifre == Sifre);
            if (uye == null) {
                return "Hatalı email yada şifre girişi.!";
            }
            Session["uye"] = uye;

            return "Hoşgeldiniz...<script type='text/javascript'>setTimeout(function(){window.location='/'},3000);</script>";
        }
    }
}