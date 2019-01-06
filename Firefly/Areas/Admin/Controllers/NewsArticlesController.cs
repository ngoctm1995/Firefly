using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firefly.Areas.Admin.Controllers
{
    public class NewsArticlesController : BaseController
    {
        // GET: Admin/NewsArticles
        public ActionResult Index(string seachString, int page = 1, int pageSize = 10)
        {
            var articles = new NewsArticles();
            var model = articles.ListAllPaging(seachString, page, pageSize);
            ViewBag.SearchString = seachString;
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(NewsCategory category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new NewsCategories();
        //        long id = dao.Insert(category);
        //        if (id > 0)
        //        {
        //            return RedirectToAction("Index", "NewsCategories");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm danh mục không thành công!");
        //        }
        //    }
        //    return View();
        //}

        //public ActionResult Edit(int id)
        //{
        //    var user = new NewsCategories().ViewDetail(id);
        //    return View(user);
        //}

        //[HttpPost]
        //public ActionResult Edit(NewsCategory category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var ncategory = new NewsCategories();
        //        bool result = ncategory.Update(category);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "NewsCategories");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Cập nhật danh mục không thành công!");
        //        }
        //    }
        //    return View("Index");
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new NewsCategories().Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}