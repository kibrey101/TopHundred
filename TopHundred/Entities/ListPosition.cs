using System;
using System.ComponentModel.DataAnnotations;

namespace TopHundred.Entities
{
    public class ListPosition
    {
        [Key]
        public Guid Id { get; set; }
        public IcoItem IcoItem { get; set; }
        [Required]
        public int PositionValue { get; set; }
        [Required]
        public DateTime PurchaseTime { get; set; }
        [Required]
        public DateTime ExpiryTime { get; set; }
        [Required, MaxLength(50)]
        public string Status { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}