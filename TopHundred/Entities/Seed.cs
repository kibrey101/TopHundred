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

            var user = await _manager.FindByEmailAsync("kib@gmail.com");
            if (user == null)
            {
                user = new Customer
                {
                    FirstName = "Kbreab",
                    LastName = "Tsegai",
                    UserName = "kib@gmail.com",
                    Email = "kib@gmail.com"
                };

                var result = await _manager.CreateAsync(user, "Passw0rd!");
                if (!result.Succeeded) throw new InvalidOperationException("failed to create user");
            }

            if (_context.IcoItems.Any()) return;
            //_context.IcoItems.RemoveRange(_context.IcoItems);
            //_context.SaveChanges();

            var icoList = new List<IcoItem>
            {
                new IcoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Test ICO",
                    Description = "Test Description",
                    Symbol = "TTT",
                    Icon = "TTT",
                    Status = "Active",
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(30),
                    WhitePaper = "emptyfile",
                    Customer = user,
                    TotalTokenCount = 1200000,
                    ListPosition =  new ListPosition
                    {
                        Id = Guid.NewGuid(),
                        PositionValue = 1,
                        PurchaseTime = DateTime.Now,
                        ExpiryTime = DateTime.Now.AddDays(12),
                        Status = ListPositionStatus.Taken,
                        Price = 12
                    },
                    IcoLinks = new List<IcoLink>
                    {
                        new IcoLink
                        {
                            Id = Guid.NewGuid(),

                        }
                    }
                },
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Ripple",
                //    Description = "micro transactions",
                //    Symbol = "XRP",
                //    Icon = "XRP",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-5),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 7000000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 2,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "BITCOIN",
                //    Description = "FIRST COIN",
                //    Symbol = "BCN",
                //    Icon = "EEE",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-10),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 3300000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 3,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "BYTECOIN",
                //    Description = "tangle network",
                //    Symbol = "BYte",
                //    Icon = "MMM",
                //    Status = "Active",
                //    StartTime = DateTime.Today,
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 9800000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 4,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "DODGE COIN",
                //    Description = "micro transactions",
                //    Symbol = "DGG",
                //    Icon = "XRP",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-5),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 1200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 5,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Ethereum",
                //    Description = "Ico platform",
                //    Symbol = "ETH",
                //    Icon = "EEE",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-10),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 3200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 6,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "BYTECOIN",
                //    Description = "tangle network",
                //    Symbol = "BYte",
                //    Icon = "MMM",
                //    Status = "Active",
                //    StartTime = DateTime.Today,
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 77200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 7,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "DODGE COIN",
                //    Description = "micro transactions",
                //    Symbol = "DGG",
                //    Icon = "XRP",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-5),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 1200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 8,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Ethereum",
                //    Description = "Ico platform",
                //    Symbol = "ETH",
                //    Icon = "EEE",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-10),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 5500000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 9,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Available,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Miota",
                //    Description = "tangle network",
                //    Symbol = "MIOTA",
                //    Icon = "MMM",
                //    Status = "Active",
                //    StartTime = DateTime.Today,
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 1200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 1,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    },
                //    IcoLinks = new List<IcoLink>
                //    {
                //        new IcoLink
                //        {
                //            Id = Guid.NewGuid(),

                //        }
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Ripple",
                //    Description = "micro transactions",
                //    Symbol = "XRP",
                //    Icon = "XRP",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-5),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 7000000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 2,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "BITCOIN",
                //    Description = "FIRST COIN",
                //    Symbol = "BCN",
                //    Icon = "EEE",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-10),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 3300000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 3,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "BYTECOIN",
                //    Description = "tangle network",
                //    Symbol = "BYte",
                //    Icon = "MMM",
                //    Status = "Active",
                //    StartTime = DateTime.Today,
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 9800000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 4,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "DODGE COIN",
                //    Description = "micro transactions",
                //    Symbol = "DGG",
                //    Icon = "XRP",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-5),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 1200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 5,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Ethereum",
                //    Description = "Ico platform",
                //    Symbol = "ETH",
                //    Icon = "EEE",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-10),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 3200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 6,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "BYTECOIN",
                //    Description = "tangle network",
                //    Symbol = "BYte",
                //    Icon = "MMM",
                //    Status = "Active",
                //    StartTime = DateTime.Today,
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 77200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 7,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "DODGE COIN",
                //    Description = "micro transactions",
                //    Symbol = "DGG",
                //    Icon = "XRP",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-5),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 1200000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 8,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Taken,
                //        Price = 12
                //    }
                //},
                //new IcoItem
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Ethereum",
                //    Description = "Ico platform",
                //    Symbol = "ETH",
                //    Icon = "EEE",
                //    Status = "Active",
                //    StartTime = DateTime.Today.AddDays(-10),
                //    EndTime = DateTime.Today.AddDays(30),
                //    WhitePaper = "emptyfile",
                //    Customer = user,
                //    TotalTokenCount = 5500000,
                //    ListPosition =  new ListPosition
                //    {
                //        Id = Guid.NewGuid(),
                //        PositionValue = 9,
                //        PurchaseTime = DateTime.Now,
                //        ExpiryTime = DateTime.Now.AddDays(12),
                //        Status = ListPositionStatus.Available,
                //        Price = 12
                //    }
                //}

            };

            _context.IcoItems.AddRange(icoList);
            _context.SaveChanges();
        }
    }
}
