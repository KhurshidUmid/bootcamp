using System;
using System.IO;
using System.Linq;
using MediaHub.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaHub.Mappers
{
    public static class ToEntity
    {
        public static Ad ToEntit(this Models.AdModel adModel)
        {
            var mFiles = adModel.Files.Select(GetEntity).ToList();

            return new Ad()
            {
                Id = Guid.NewGuid(),
                Title = adModel.Title,
                Description = adModel.Description,
                Tags = string.Join(',', adModel.Tags),
                Medias = mFiles
            };
        }


        private static Media GetEntity(IFormFile file)
        {
            var stream = new MemoryStream();

            file.CopyTo(stream);

            return new Media()
            {
                Id = Guid.NewGuid(),
                ContentType = file.ContentType,
                Data = stream.ToArray()

            };
        }        
    }
}