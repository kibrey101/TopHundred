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
    public class IcosListController : Controller
    {
        private IcoListContext _context;

        public IcosListController(IcoListContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {           
            return View(await _context.IcoItems.OrderByDescending(a => a.StartTime).ToListAsync());
        }
        [HttpGet("/upcoming")]
        public IActionResult Upcoming()
        {
            return View();
        }
    }
}
