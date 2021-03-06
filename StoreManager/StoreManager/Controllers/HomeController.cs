﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Models;
using StoreManager.Repository;

namespace StoreManager.Controllers
{
    public class HomeController : Controller
    {
        public iProductsRepository productRepo;
        public HomeController(iProductsRepository productsRepository)
        {
            this.productRepo = productsRepository;
        }

        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            List<Products> products = productRepo.GetAll();
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
