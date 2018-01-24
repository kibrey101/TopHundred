using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TopHundred.Entities
{
    public enum SocialMeidaLinksEnumeration { Facebook = 0, Twitter, Website, Instagram, Medium, Other }
    public class IcoLink
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public SocialMeidaLinksEnumeration LinkIcon { get; set; }
        [ForeignKey("IcoItemId")]
        public IcoItem IcoItem { get; set; }
        public Guid IcoItemId { get; set; }
    }
}
