using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace pizza.Models
{
    public class Pizza
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Ingradients { get; set; }

        [Required]
        // [MaxLength(1000)]
        public double Price { get; set; }

        [Required]
        public EPizzaStockStatus? StockStatus { get; set; }
        
        
        
    }
}