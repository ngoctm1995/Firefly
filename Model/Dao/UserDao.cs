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
        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
