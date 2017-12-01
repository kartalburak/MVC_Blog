using Blog.DAL.Context;
using Blog.DAL.Repositories;
using Blog.DAL.UnitOfWork;
using Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Presentation.Controllers
{
    public class HomeController : Controller
    {
        BlogContext ent = new BlogContext();
        UnitOfWork unitofwork = new UnitOfWork(new BlogContext());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SonMakaleler()
        {
            //Makale:_dbset
            //ent:_dbcontext
            //Repository<Makale> repo = new Repository<Makale>(ent);
            //return PartialView(repo.GetAll(null, m => m.OrderByDescending(x => x.Tarih), m => m.Uye, m => m.Yorumlar, m => m.Etiketler).Take(3).ToList());
            var sonuc = unitofwork.Repository<Makale>().GetAll(null, m => m.OrderByDescending(x => x.Tarih), m => m.Uye, m => m.Yorumlar, m => m.Etiketler).Take(3).ToList();

            return PartialView(sonuc);
        }
        public ActionResult SonYorumlar()
        {
            //Repository<Yorum> repo = new Repository<Yorum>(ent);
            //return PartialView(repo.GetAll(null, m => m.OrderByDescending(x => x.Tarih)).Take(3).ToList());
            var sonuc = unitofwork.Repository<Yorum>().GetAll(null, m => m.OrderByDescending(x => x.Tarih)).Take(3).ToList();
            return PartialView(sonuc);
        }
        public ActionResult CokKullanilanEtiketler()
        {
            //Repository<Etiket> repo = new Repository<Etiket>(ent);
            //return PartialView(repo.GetAll(null, n => n.OrderByDescending(e => e.Makaleler.Count())).Take(5).ToList());
            var sonuc = unitofwork.Repository<Etiket>().GetAll(null, n => n.OrderByDescending(e => e.Makaleler.Count())).Take(5).ToList();
            return PartialView(sonuc);
        }
        public ActionResult MakalelerByEtiket(int etiketid)
        {

            //Repository<Etiket> repo = new Repository<Etiket>(ent);
            //return View(repo.Get(x => x.ID == etiketid).Makaleler.ToList());
            var sonuc = unitofwork.Repository<Etiket>().Get(x => x.ID == etiketid).Makaleler.ToList();
            return View(sonuc);

        }
        public ActionResult MakaleFromYorum(int makaleid)
        {
            //Repository<Makale> repo = new Repository<Makale>(ent);
            //var makale = repo.GetById(makaleid);
            //return View(makale);
            var sonuc = unitofwork.Repository<Makale>().GetById(makaleid);
            return View(sonuc);



        }
    }
}