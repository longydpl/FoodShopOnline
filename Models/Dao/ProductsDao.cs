using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace FoodShopOnline.Models.Dao
{
    public class ProductsDao
    {
        OnlineFoodShop db = null;

        public ProductsDao()
        {
            db = new OnlineFoodShop();
        }


        public List<FoodShopOnline.ViewModel.Products> ListProduct(int number)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle
                        };
            return model.Take(number).ToList();
        }

        public List<FoodShopOnline.ViewModel.Products> GetListProductById(long? ID)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        where b.ID == ID 
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle,
                            CategoryName = b.Name
                        };
            return model.Take(4).ToList();
        }

        public IPagedList<FoodShopOnline.ViewModel.Products> GetProducts(int pageNumber,int pageSize)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle,
                            CategoryName = b.Name,
                            Description = a.Detail,
                            CreateDate = a.CreatedDate
                        };
            model = model.OrderBy(x => x.ID);
            return model.ToPagedList(pageNumber, pageSize);
        }



        public IPagedList<FoodShopOnline.ViewModel.Products> GetNewProducts(int pageNumber, int pageSize)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle,
                            CategoryName = b.Name,
                            Description = a.Detail,
                            CreateDate = a.CreatedDate
                        };
            model = model.OrderByDescending(x => x.CreateDate).Take(25);
            return model.ToPagedList(pageNumber, pageSize);
        }


        public IPagedList<FoodShopOnline.ViewModel.Products> GetSpecialProducts(int pageNumber, int pageSize)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle,
                            CategoryName = b.Name,
                            Description = a.Detail,
                            CreateDate = a.CreatedDate,
                            CountView = a.CountView
                        };
            model = model.OrderByDescending(x => x.CountView).Take(12);
            return model.ToPagedList(pageNumber, pageSize);
        }


        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        public IPagedList<FoodShopOnline.ViewModel.Products> GetProductsByCateID(long id,int pageNumber, int pageSize)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        where a.CategoryID == id
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle,
                            CategoryName = b.Name,
                            Description = a.Detail,
                            CreateDate = a.CreatedDate
                        };
            model = model.OrderBy(x => x.ID);
            return model.ToPagedList(pageNumber, pageSize);
        }

        public IPagedList<FoodShopOnline.ViewModel.Products> GetSearchProducts(int pageNumber, int pageSize, string keyword)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        where a.Name.Contains(keyword)
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.Name,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.MetaTitle,
                            CategoryName = b.Name,
                            Description = a.Detail,
                            CreateDate = a.CreatedDate
                        };
            model = model.OrderBy(x => x.ID);
            return model.ToPagedList(pageNumber, pageSize);
        }


    }
}