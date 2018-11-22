using Model.EF;
using System.Linq;

namespace Model.Dao
{
    class UserDao
    {
        FireflyDbConText db = null;
        public UserDao()
        {
            db = new FireflyDbConText();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
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
