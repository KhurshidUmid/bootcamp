using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pizza.Models
{
    public class PizzaRequest
    {
        
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(1024)]
        public List<string> Ingradients { get; set; }

        [Range(1, double.MaxValue)]
        // [MaxLength(1000)]
        public double Price { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPizzaStockStatus StockStatus { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}