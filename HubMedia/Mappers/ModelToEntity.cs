using System;
using System.IO;
using System.Linq;
using HubMedia.Entities;
using HubMedia.Models;
using Microsoft.AspNetCore.Http;

namespace HubMedia.Mappers
{
    public static class ModelEntityMappers
    {
        public static Ad ToEntity(this AdModel ad)
        {
            var mFiles = ad.Files.Select(GetImageEntity).ToList();

            return new Ad()
            {
                Id = Guid.NewGuid(),
                Title = ad.Title,
                Description = ad.Description,
                Tags = string.Join(',', ad.Tags),
                Medias = mFiles
            };
        }

        private static Media GetImageEntity(IFormFile file)
        {
            using var stream = new MemoryStream();

            file.CopyTo(stream);

            return new Media()
            {
                Id = Guid.NewGuid(),
                ContentType = file.ContentType,
                Data = stream.ToArray()

            };
        }


        public static Ad ToEntity(this UpdateAd ad)
        {            
            return new Ad()
            {
                Id = ad.Id,
                Title = ad.Title,
                Description = ad.Description,
                Tags = string.Join(',', ad.Tags)
                
            };
        }

    }

}
