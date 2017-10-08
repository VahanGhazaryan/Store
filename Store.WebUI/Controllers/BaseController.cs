using AutoMapper;
using Store.DAL.Entities;
using Store.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebUI.Controllers
{
    public class BaseController : Controller
    {
        private MapperConfiguration config;

        protected IMapper mapper;
        public BaseController()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductCategoryViewModel, ProductCategory>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
            });
            mapper = config.CreateMapper();
        }

    }
}