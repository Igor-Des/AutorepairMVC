using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutorepairMVC.Data;
using AutorepairMVC.Models;

namespace AutorepairMVC.Controllers
{
    public class OwnersController : Controller
    {
        private readonly AutorepairContext _context;

        public OwnersController(AutorepairContext context)
        {
            _context = context;
        }


        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 258)]
        public async Task<IActionResult> Index()
        {
            Thread.Sleep(3000);
            return View(await _context.Owners.ToListAsync());
        }
    }
}
