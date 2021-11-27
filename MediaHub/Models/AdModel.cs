using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MediaHub.Models
{
    public class AdModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public IEnumerable<IFormFile> Files { get; set; }
    }
}