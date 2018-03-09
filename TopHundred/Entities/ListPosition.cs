using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Entities
{
    public enum ListPositionStatus
    {
        Available = 0, Reserved, Taken
    }

    public class ListPosition
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("IcoItemId")]
        public IcoItem IcoItem { get; set; }
        public Guid IcoItemId { get; set; }
        [Required]
        public int PositionValue { get; set; }
        [Required]
        public DateTime PurchaseTime { get; set; }
        [Required]
        public DateTime ExpiryTime { get; set; }
        [Required, MaxLength(50)]
        public ListPositionStatus Status { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}