using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TopHundred.Entities
{
    public sealed class IcoListContext : IdentityDbContext<Customer>
    {
        public IcoListContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<IcoItem> IcoItems { get; set; }
        public DbSet<ListPosition> ListPositions { get; set; }
        public DbSet<PositionRequest> PositionRequests { get; set; }    
    }
}
