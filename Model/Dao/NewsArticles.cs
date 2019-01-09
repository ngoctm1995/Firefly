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

        public bool Update(NewsCategory entity)
        {
            try
            {
                var category = db.NewsCategories.Find(entity.id);
                category.name = entity.name;
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
                var articleCategory = db.NewsArticleCategories.Where(a => a.newsArticleID == id).SingleOrDefault();
                db.NewsArticles.Remove(category);
                db.NewsArticleCategories.Remove(articleCategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public NewsCategory ViewDetail(int id)
        {
            return db.NewsCategories.Find(id);
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
    }
}
