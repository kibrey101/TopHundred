using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopHundred.Entities;

namespace TopHundred.Controllers
{
    public class IcosListController : Controller
    {
        private readonly IcoListContext _context;

        public IcosListController(IcoListContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _context.IcoItems.Include(a => a.ListPosition).OrderBy(a => a.ListPosition.PositionValue)
                .ToListAsync();
            return View(items);
        }
        [HttpGet("icos/{id}")]
        public IActionResult IcoDetail(Guid id)
        {
            var item = _context.IcoItems.Include(a => a.ListPosition).FirstOrDefault(a => a.Id == id);
            return View(item);
        }

        [HttpGet("upcoming")]
        public IActionResult Upcoming()
        {
            return View();
        }

        //[Authorize]
        [HttpGet("submit")]
        public IActionResult SubmitIco()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }
    }
}
