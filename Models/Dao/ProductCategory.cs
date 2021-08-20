using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShopOnline.Models.EF;

namespace FoodShopOnline.Models.Dao
{
    public class ProductCategory
    {
        OnlineFoodShop db = null;
        public ProductCategory()
        {
            db = new OnlineFoodShop();
        }

        public string GetParentName(long? parentID)
        {
            string parentName = "Null";
            IQueryable<EF.ProductCategory> productCategories = db.ProductCategories.Where(p => p.ID == parentID);
            foreach( var item in productCategories)
            {
                parentName = item.Name;
            }
            return parentName;
        }
        public List<EF.ProductCategory> GetByParentID(long? id)
        {
            return db.ProductCategories.Where(p => p.ParentID == id).ToList();
        }

    }
}