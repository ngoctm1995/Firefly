using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firefly.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var newArticles = new NewsArticles();
            ViewBag.NewsArticles1 = newArticles.ListNewsArticle1(1);
            ViewBag.NewsArticles6 = newArticles.ListNewsArticle6(1);
            ViewBag.NewsArticles2 = newArticles.ListNewsArticle2(5);
            ViewBag.NewsArticles3 = newArticles.ListNewsArticle3(1);
            ViewBag.NewsArticles4 = newArticles.ListNewsArticle4(5);
            ViewBag.NewsArticles5 = newArticles.ListNewsArticle5(7);

            return View();
        }

        //[ChildActionOnly]
        //public ActionResult MainMenu()
        //{
        //    var model = new NewsCategories().GetCategory();
        //    return PartialView(model);
        //}

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult FooterMenu()
        {
            var model = new NewsCategories().GetCategory();
            return PartialView(model);
        }

    }
}