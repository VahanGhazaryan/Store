using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Store.DAL;
using Store.DAL.Abstract;
using Store.DAL.Entities;
using Store.WebUI.Controllers;
using Store.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Store.Test
{
    [TestClass]
    public class RepoUnitTest
    {
        [TestMethod]
        public void Get_Products_Test()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetProducts()).Returns(new List<Product>
            {
                new Product() { ProductId = 1, Name = "aaaa", Description = "a", Price = 10,  CategoryId = 1 },
                new Product() { ProductId = 2, Name = "bbbb", Description = "b", Price = 16,  CategoryId = 1 },
                new Product() { ProductId = 3, Name = "cccc", Description = "c", Price = 20,  CategoryId = 1 },
                new Product() { ProductId = 4, Name = "dddd", Description = "d", Price = 12,  CategoryId = 2 },
                new Product() { ProductId = 5, Name = "eeee", Description = "d", Price = 23,  CategoryId = 2 },
                new Product() { ProductId = 6, Name = "ffff", Description = "d",  Price = 23,  CategoryId = 2 },
                new Product() { ProductId = 7, Name = "hhhh", Description = "d", Price = 23,  CategoryId = 2 },
            });
            ProductController controller = new ProductController(mock.Object, null);

            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 1).Model;

            Assert.IsNotNull(result);
        }
    }
}
