using FoodShopOnline.Models.EF;
using System.Linq;

namespace FoodShopOnline.Models.Dao
{
    public class UserDao
    {
        OnlineFoodShop db = null;

        public UserDao()
        {
            db = new OnlineFoodShop();
        }

        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord) return 1;
                    else return -2;
                }
            }
        }
    }
}