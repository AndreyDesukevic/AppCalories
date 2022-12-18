﻿using AppCalories.DAL.Interfaces;
using AppCalories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppCalories.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
       

        public HomeController(IProductRepository productRepository)
        {
           
            _productRepository = productRepository;
        }

        public  async Task<IActionResult> Index()
        {
            var response = await _productRepository.Select();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
