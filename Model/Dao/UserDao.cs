using Model.EF;
using System.Linq;

namespace Model.Dao
{
    public class UserDao
    {
        TechFireFlyDbContext db = null;
        public UserDao()
        {
            db = new TechFireFlyDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetById(string UserName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == UserName);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
