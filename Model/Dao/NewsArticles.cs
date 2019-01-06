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

        public long Insert(NewsCategory entity)
        {
            db.NewsCategories.Add(entity);
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
                var category = db.NewsCategories.Find(id);
                db.NewsCategories.Remove(category);
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

        public IEnumerable<NewsArticle> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<NewsArticle> model = db.NewsArticles;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.headline.Contains(seachString) || x.headline.Contains(seachString));
            }
            return model.OrderByDescending(x => x.headline).ToPagedList(page, pageSize);
        }

        public IQueryable<NewsCategory> ListCategories()
        {
            var qCategory = from nc in db.NewsCategories
                            select nc;
            return qCategory;
        }
    }
}
