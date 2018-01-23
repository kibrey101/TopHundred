using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopHundred.Entities;

namespace TopHundred.Controllers
{
    public class AppController : Controller
    {
        private IcoListContext _context;

        public AppController(IcoListContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {           
            return View(await _context.IcoItems.ToListAsync());
        }
    }
}
