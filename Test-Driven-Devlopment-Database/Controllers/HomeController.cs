﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_Driven_Development_Library.Interfaces;
using Test_Driven_Devlopment_Database.Models;

namespace Test_Driven_Devlopment_Database.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserREpository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserREpository userREpository)
        {
            _logger = logger;
            _userRepository = userREpository;
        }

        public IActionResult Index()
        {
            _userRepository.Validate(new Test_Driven_Development_Library.DTOs.User { Id = 1, Emailadress = "test@hotmail.com", LastName = "kljsdflkjd", Name = "sdfgkhdsa" });
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
