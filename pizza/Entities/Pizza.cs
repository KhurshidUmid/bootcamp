using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace pizza.Entities
{
    public class Pizza
    {        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Ingradients { get; set; }

        [Range(1, double.MaxValue)]
        // [MaxLength(1000)]
        public double Price { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }


        [Required]
        public EPizzaStockStatus StockStatus { get; set; }


        [Obsolete("Used only for entity binding", true)]
        public Pizza() { }
        public Pizza(string title, string shortName, string ingradients, double price, EPizzaStockStatus stockStatus)
        {
            Id = Guid.NewGuid();
            Title = title;
            ShortName = shortName;
            Ingradients = ingradients;
            Price = price;
            StockStatus = stockStatus;
            CreatedAt = DateTimeOffset.UtcNow;
            ModifiedAt = CreatedAt;

        }

    }
}