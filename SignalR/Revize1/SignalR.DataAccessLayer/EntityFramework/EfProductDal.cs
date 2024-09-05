﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {

        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values=context.Products.Include(x=>x.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
			using var context= new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context=new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();

		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();

		}

		public string ProductNamePriceMax()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductPrice == (context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNamePriceMin()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductPrice == (context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x => x.ProductPrice);
		}

		public decimal ProductAvgPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger")
			.Select(z => z.CategoryID).FirstOrDefault())).Average(w=>w.ProductPrice);
		}

		public decimal ProductPriceBySteakBurger()
		{
			using var context= new SignalRContext();
			return context.Products.Where(x=>x.ProductName=="Steak Burger").Select(y=>y.ProductPrice).FirstOrDefault();
		}

		public decimal TotalPriceByDrinkCategory()
		{
			using var context = new SignalRContext();
			int id=context.Categories.Where(x=>x.CategoryName=="İçecek").Select(y=>y.CategoryID).FirstOrDefault();
			return context.Products.Where(x => x.CategoryID == id).Sum(y => y.ProductPrice);
		}

		public decimal TotalPriceBySaladCategory()
		{
			using var context = new SignalRContext();
			int id = context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
			return context.Products.Where(x => x.CategoryID == id).Sum(y => y.ProductPrice);
		}
	}
}