using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TopHundred.Entities
{
    public class Customer : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public IEnumerable<IcoItem> IcoItems { get; set; } = new List<IcoItem>();
    }
}