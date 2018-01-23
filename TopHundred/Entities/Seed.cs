using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;

namespace TopHundred.Entities
{
    public class Seed
    {
        private readonly IcoListContext _context;
        private readonly UserManager<Customer> _manager;

        public Seed(IcoListContext context, UserManager<Customer> manager)
        {
            _context = context;
            _manager = manager;
        }
        public  async Task SeedDatabase()
        {

            var user = await _manager.FindByEmailAsync("kib@gmail.com") ?? 
                       new Customer
                       {
                           FirstName = "Kbreab", LastName = "Tsegai", UserName = "kib@gmail.com", Email = "kib@gmail.com"
                       };
            var result = await _manager.CreateAsync(user);
            if (!result.Succeeded) throw new InvalidOperationException("failed to create user");
            if (_context.IcoItems.Any()) return;

            var icoList = new List<IcoItem>
            {
                new IcoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Miota",
                    Description = "tangle network",
                    Symbol = "MIOTA",
                    Icon = "MMM",
                    Status = "Active",
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(30),
                    WhitePaper = "emptyfile",
                    Customer = user
                },
                new IcoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Ripple",
                    Description = "micro transactions",
                    Symbol = "XRP",
                    Icon = "XRP",
                    Status = "Active",
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(30),
                    WhitePaper = "emptyfile",
                    Customer = user
                },
                new IcoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Ethereum",
                    Description = "Ico platform",
                    Symbol = "ETH",
                    Icon = "EEE",
                    Status = "Active",
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(30),
                    WhitePaper = "emptyfile",
                    Customer = user
                }
            };

            _context.IcoItems.AddRange(icoList);
            _context.SaveChanges();
        }
    }
}
