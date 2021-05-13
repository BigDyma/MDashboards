using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text; 
namespace Entity.Models
{
    public class Plan: EntityBase
    {
        [MaxLength(128)]
        public string Name { get; set; }
        
        [Range(0, 1 << 20)]
        public decimal PricePerMonth { get; set; }
    }
}
