using FoodShopOnline.Models.EF;

namespace FoodShopOnline.Models.Dao
{
    public class UserDao
    {
        OnlineFoodShop db = null;

        public UserDao()
        {
            db = new OnlineFoodShop();
        }


    }
}