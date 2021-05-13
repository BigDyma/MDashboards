using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public class PaymentDetails : EntityBase
    {
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

    }
}
