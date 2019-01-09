using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsArticles
    {
        TechFireFlyDbContext db = null;

        public NewsArticles()
        {
            db = new TechFireFlyDbContext();
        }

        public long Insert(NewsArticle entity)
        {
            db.NewsArticles.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public bool Update(NewsArticle entity)
        {
            try
            {
                var article = db.NewsArticles.Find(entity.id);
                article.CategoryID = entity.CategoryID;
                article.headline = entity.headline;
                article.extract = entity.extract;
                article.encoding = entity.encoding;
                article.text = entity.text;
                article.publishDate = entity.publishDate;
                article.byLine = entity.byLine;
                article.source = entity.source;
                article.state = entity.state;
                article.clientQuote = entity.clientQuote;
                article.createdDate = entity.createdDate;
                article.lastModifiedDate = entity.lastModifiedDate;
                article.htmlMetaDescription = entity.htmlMetaDescription;
                article.htmlMetaKeywords = entity.htmlMetaKeywords;
                article.htmlMetaLangauge = entity.htmlMetaLangauge;
                article.tags = entity.tags;
                article.priority = entity.priority;
                article.format = entity.format;
                article.photoWidth = entity.photoWidth;
                article.photoHeight = entity.photoHeight;
                article.photoHtmlAlt = entity.photoHtmlAlt;
                article.photoURL = entity.photoURL;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.NewsArticles.Find(id);
                //var articleCategory = db.NewsArticleCategories.Where(a => a.newsArticleID == id).SingleOrDefault();
                db.NewsArticles.Remove(category);
                //db.NewsArticleCategories.Remove(articleCategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public NewsArticle ViewDetail(int id)
        {
            return db.NewsArticles.Find(id);
        }

        public List<NewsArticle> ListNewsArticle1(int top)
        {
            return db.NewsArticles.Where(x => x.priority == 1).OrderByDescending(x => x.createdDate).Take(top).ToList();
        }

        public List<NewsArticle> ListNewsArticle2(int top)
        {
            return db.NewsArticles.Where(x => x.priority == 2).OrderByDescending(x => x.createdDate).Take(top).ToList();
        }
        public List<NewsArticle> ListNewsArticle3(int top)
        {
            return db.NewsArticles.Where(x => x.priority == 3).OrderByDescending(x => x.createdDate).Take(top).ToList();
        }
        public List<NewsArticle> ListNewsArticle4(int top)
        {
            return db.NewsArticles.Where(x => x.priority == 4).OrderByDescending(x => x.createdDate).Take(top).ToList();
        }
        public List<NewsArticle> ListNewsArticle5(int top)
        {
            return db.NewsArticles.Where(x => x.priority == 2).OrderByDescending(x => x.createdDate).Take(top).ToList();
        }
        public List<NewsArticle> ListNewsArticle6(int top)
        {
            return db.NewsArticles.Where(x => x.priority == 2).OrderByDescending(x => x.createdDate).Take(top).ToList();
        }
    }
}
