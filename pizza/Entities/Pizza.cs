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
        public string ShortName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Ingradients { get; set; }

        [Required]
        // [MaxLength(1000)]
        public double Price { get; set; }

        [Required]
        public EPizzaStockStatus StockStatus { get; set; }


        [Obsolete("Used only for entity binding", true)]
        public Pizza() { }
        public Pizza(string title = "", string shortName = "", string ingradients = "", double price = 0.0, EPizzaStockStatus stockStatus = EPizzaStockStatus.None)
        {
            Id = Guid.NewGuid();
            Title = title;
            ShortName = shortName;
            Ingradients = ingradients;
            Price = price;
            StockStatus = stockStatus;

        }

    }
}