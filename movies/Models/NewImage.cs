using System.ComponentModel.DataAnnotations;

namespace movies.Models
{
    public class NewImage
    {

        [Required]
        [MaxLength(20)]
        public byte Data { get; set; }
    }

}