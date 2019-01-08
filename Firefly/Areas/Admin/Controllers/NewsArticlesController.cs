using Firefly.Areas.Admin.Models;
using Model.Dao;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firefly.Areas.Admin.Controllers
{
    public class NewsArticlesController : BaseController
    {
        TechFireFlyDbContext db = new TechFireFlyDbContext();

        // GET: Admin/NewsArticles
        public ActionResult Index(string seachString, int page = 1, int pageSize = 10)
        {
            var model = ListAllPaging(seachString, page, pageSize);
            ViewBag.SearchString = seachString;
            return View(model);
        }

        public IEnumerable<ArticlesModel> ListAllPaging(string seachString, int page, int pageSize)
        {
            var model = from nc in db.NewsCategories
                        join nac in db.NewsArticleCategories on nc.id equals nac.newsCategoryID
                        join na in db.NewsArticles on nac.newsArticleID equals na.id

                        select new ArticlesModel
                        {
                            id = na.id,
                            newsCategoryID = nc.id,
                            newsCategory = nc.name,
                            headline = na.headline,
                            publishDate = na.publishDate,
                            byLine = na.byLine
                        }; 

            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.headline.Contains(seachString) || x.headline.Contains(seachString));
            }
            return model.OrderByDescending(x => x.headline).ToPagedList(page, pageSize);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListCategories = new SelectList(db.NewsCategories.AsEnumerable(), "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticlesModel article)
        {
            if (ModelState.IsValid)
            {
                var articleDetails = new NewsArticle
                {
                    headline = article.headline,
                    byLine = article.byLine,
                    source = article.source,
                    text = article.text,
                    createdDate = DateTime.Now,
                    lastModifiedDate = DateTime.Now,
                    publishDate = DateTime.Now,
                    photoURL = article.photoURL
                };

                var articlesCategory = new NewsArticleCategory();

                using (var context = new TechFireFlyDbContext())
                {
                    context.NewsArticles.Add(articleDetails);
                    articlesCategory.newsArticleID = articleDetails.id;
                    articlesCategory.newsCategoryID = article.newsCategoryID;
                    context.NewsArticleCategories.Add(articlesCategory);
                    context.SaveChanges();
                };

                if (articleDetails.id > 0)
                    return RedirectToAction("Index", "NewsArticles");
                else
                    ModelState.AddModelError("", "Thêm tin tức không thành công!");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new NewsCategories().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(ArticlesModel category)
        {
            if (ModelState.IsValid)
            {
                //var ncategory = new NewsCategories();
                //bool result = ncategory.Update(category);
                //if (result)
                //{
                //    return RedirectToAction("Index", "NewsCategories");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Cập nhật danh mục không thành công!");
                //}
            }
            return View("Index");
        }

        //public bool Update(ArticlesModel model)
        //{
        //    try
        //    {
        //        var article = db.NewsArticles.Find(model.id);
        //        article.headline = article.headline;
        //        article.byLine = article.byLine;
        //        article.source = article.source;
        //        article.text = article.text;
        //        article.lastModifiedDate = DateTime.Now;

        //        var articleCategory = db.NewsArticleCategories.Where(a => a.newsArticleID == model.id).SingleOrDefault();
        //        articleCategory.newsCategoryID = articleCategory

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }s
        //}

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewsArticles().Delete(id);
            return RedirectToAction("Index");
        }
    }
}