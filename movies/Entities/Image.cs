using System;

namespace movies.Entities
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public byte[] Data { get; set; }

        public Guid MovieId { get; set; }
        
        
    }
}