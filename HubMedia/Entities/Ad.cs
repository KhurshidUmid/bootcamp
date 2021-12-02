using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HubMedia.Entities
{
    public class Ad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public ICollection<Media> Medias { get; set; }

        // [Obsolete("Used only for Entities binding.", true)]
        // public Ad() { }

        // public Ad(string title, string description, string tags, ICollection<Media> medias)
        // {
        //     Id = Guid.NewGuid();
        //     Title = title;
        //     Description = description;
        //     Tags = tags;
        //     Medias = medias;
        // }
    }
}