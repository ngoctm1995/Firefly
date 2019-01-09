using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firefly.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
           
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new NewsCategories().GetCategory();
            return PartialView(model);
        }

        public ActionResult Category(int cateId)
        {
            var newArticles = new NewsArticles();
            ViewBag.NewsArticles1 = newArticles.ListNewsArticle1(2);
            ViewBag.NewsArticles2 = newArticles.ListNewsArticle2(5);
            ViewBag.NewsArticles3 = newArticles.ListNewsArticle3(1);
            ViewBag.NewsArticles4 = newArticles.ListNewsArticle4(5);
            ViewBag.NewsArticles5 = newArticles.ListNewsArticle5(7);

            var category = new NewsCategories().ViewDetail(cateId);
            return View(category);
        }
    }
}