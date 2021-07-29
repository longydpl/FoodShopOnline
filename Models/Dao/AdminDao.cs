using FoodShopOnline.Models.EF;
using System.Linq;

namespace FoodShopOnline.Models.Dao
{
    public class AdminDao
    {
        OnlineFoodShop db = null;

        public AdminDao()
        {
            db = new OnlineFoodShop();
        }

        public Admins GetByID(string userName)
        {
            return db.Admins.SingleOrDefault(x => x.Username == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Admins.SingleOrDefault(x => x.Username == userName);
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