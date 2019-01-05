using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsCategories
    {
        TechFireFlyDbContext db = null;

        public NewsCategories()
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

        public IEnumerable<NewsCategory> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<NewsCategory> model = db.NewsCategories;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.name.Contains(seachString) || x.name.Contains(seachString));
            }
            return model.OrderByDescending(x => x.name).ToPagedList(page, pageSize);
        }
    }
}
