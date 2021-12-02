using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HubMedia.Models
{
    public class UpdateAd
    {
        
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string Tags { get; set; }

        
    }
}