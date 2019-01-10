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
            var model = from nc in db.NewsArticles
                            //join nac in db.NewsArticleCategories on nc.id equals nac.newsCategoryID
                        join na in db.NewsCategories on nc.CategoryID equals na.id

                        select new ArticlesModel
                        {
                            id = nc.id,
                            CategoryID = nc.id,
                            newsCategory = na.name,
                            headline = nc.headline,
                            publishDate = nc.publishDate,
                            byLine = nc.byLine
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
                    CategoryID = article.CategoryID,
                    extract = article.extract,
                    encoding = article.encoding,
                    tags = article.tags,
                    priority = article.priority,
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
                    //articlesCategory.newsArticleID = articleDetails.id;
                    //articlesCategory.newsCategoryID = article.newsCategoryID;
                    //context.NewsArticleCategories.Add(articlesCategory);
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
            var user = new NewsArticles().ViewDetail(id);
            Models.ArticlesModel objArticle = new ArticlesModel();
            // Parse data
            objArticle.id = user.id;
            objArticle.CategoryID = user.CategoryID;
            objArticle.headline = user.headline;
            objArticle.extract = user.extract;
            objArticle.encoding = user.encoding;
            objArticle.text = user.text;
            objArticle.publishDate = user.publishDate;
            objArticle.byLine = user.byLine;
            objArticle.source = user.source;
            objArticle.state = user.state;
            //objArticle.clientQuote = user.clientQuote;
            objArticle.createdDate = user.createdDate;
            objArticle.lastModifiedDate = user.lastModifiedDate;
            objArticle.htmlMetaDescription = user.htmlMetaDescription;
            objArticle.htmlMetaKeywords = user.htmlMetaKeywords;
            objArticle.htmlMetaLangauge = user.htmlMetaLangauge;
            objArticle.tags = user.tags;
            objArticle.priority = user.priority;
            //objArticle.format = user.format;
            objArticle.photoHtmlAlt = user.photoHtmlAlt;
            //objArticle.photoWidth = user.photoWidth;
            //objArticle.photoHeight = user.photoHeight;
            objArticle.photoURL = user.photoURL;
            ViewBag.ListCategories = new SelectList(db.NewsCategories.AsEnumerable(), "id", "name");
            return View(objArticle);
        }
        [HttpPost]
        public ActionResult Edit(ArticlesModel category)
        {
            if (ModelState.IsValid)
            {
                var narticle = new NewsArticles();
                NewsArticle newArticle = db.NewsArticles.Find(category.id);
                newArticle.CategoryID = category.CategoryID;
                newArticle.headline = category.headline;
                newArticle.extract = category.extract;
                newArticle.encoding = category.encoding;
                newArticle.text = category.text;
                //newArticle.publishDate = category.publishDate;
                newArticle.byLine = category.byLine;
                newArticle.source = category.source;
                newArticle.state = category.state;
                //newArticle.clientQuote = category.clientQuote;
                newArticle.lastModifiedDate = DateTime.Now;
                newArticle.htmlMetaDescription = category.htmlMetaDescription;
                newArticle.htmlMetaKeywords = category.htmlMetaKeywords;
                newArticle.htmlMetaLangauge = category.htmlMetaLangauge;
                newArticle.tags = category.tags;
                newArticle.priority = category.priority;
                //newArticle.format = category.format;
                newArticle.photoHtmlAlt = category.photoHtmlAlt;
                //newArticle.photoWidth = category.photoWidth;
                //newArticle.photoHeight = category.photoHeight;
                newArticle.photoURL = category.photoURL;
                bool result = narticle.Update(newArticle);
                if (result)
                {
                    return RedirectToAction("Index", "NewsArticles");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin tức không thành công!");
                }
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
        public ActionResult Details(int id)
        {
            var user = new NewsArticles().ViewDetail(id);
            Models.ArticlesModel objArticle = new ArticlesModel();
            // Parse data
            objArticle.id = user.id;
            objArticle.CategoryID = user.CategoryID;
            objArticle.newsCategory = db.NewsCategories.Find(user.CategoryID).name;
            objArticle.headline = user.headline;
            objArticle.extract = user.extract;
            objArticle.encoding = user.encoding;
            objArticle.text = user.text;
            objArticle.publishDate = user.publishDate;
            objArticle.byLine = user.byLine;
            objArticle.source = user.source;
            objArticle.state = user.state;
            //objArticle.clientQuote = user.clientQuote;
            objArticle.createdDate = user.createdDate;
            objArticle.lastModifiedDate = user.lastModifiedDate;
            objArticle.htmlMetaDescription = user.htmlMetaDescription;
            objArticle.htmlMetaKeywords = user.htmlMetaKeywords;
            objArticle.htmlMetaLangauge = user.htmlMetaLangauge;
            objArticle.tags = user.tags;
            objArticle.priority = user.priority;
            //objArticle.format = user.format;
            objArticle.photoHtmlAlt = user.photoHtmlAlt;
            //objArticle.photoWidth = user.photoWidth;
            //objArticle.photoHeight = user.photoHeight;
            objArticle.photoURL = user.photoURL;
            ViewBag.Title = objArticle.headline;
            return View(objArticle);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewsArticles().Delete(id);
            return RedirectToAction("Index");
        }
    }
}