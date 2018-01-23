using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Entities;

namespace TopHundred.Services
{
    public class IcoRepository
    {
        private IcoListContext _context;

        public IcoRepository(IcoListContext context)
        {
            _context = context;
        }


    }
}
