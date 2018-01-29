using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopHundred.Entities;

namespace TopHundred.Services
{
    public class IcoRepository
    {
        private readonly IcoListContext _context;

        public IcoRepository(IcoListContext context)
        {
            _context = context;
        }

        public IEnumerable<IcoItem> GetIcoItems()
        {
            return _context.IcoItems.Include(a => a.ListPosition).OrderBy(a => a.ListPosition.PositionValue).ToList();
        }
        public IcoItem GetIcoItem(Guid id)
        {
            return _context.IcoItems.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Users.OrderBy(u => u.FirstName).ThenBy(u => u.LastName).ToList();
        }

        public Customer GetCustomer(string id)
        {
            return _context.Users.Include(u => u.IcoItems).FirstOrDefault(u => u.Id == id);
        }


    }
}
