using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace HubMedia.Entities
{
    public class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength]
        public string ContentType { get; set; }

        public double SizeInMb
        {
            get => Data.Length / (double)(1024 * 1024);
        }


        [Required]
        [MaxLength(5 * 1024 * 1024)]
        public byte[] Data { get; set; }

        // [Obsolete("Used only for Entities binding.", true)]
        // public Media() { }

        // public Media(string contentType, byte[] data)
        // {
        //     Id = Guid.NewGuid();
        //     ContentType = contentType;
        //     Data = data;
        // }
    }
}