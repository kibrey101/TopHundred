using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Entities
{
    public class PositionRequest
    {
        public Guid Id { get; set; }
        public ListPosition ListPosition { get; set; }
        public IcoItem IcoItem { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }   
    }
}
