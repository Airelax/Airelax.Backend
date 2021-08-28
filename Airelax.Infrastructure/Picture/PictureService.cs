using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Airelax.Infrastructure.Picture.Abstractions;
using CloudinaryDotNet.Actions;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Airelax.Infrastructure.Picture
{
    [DependencyInjection(typeof(IPictureService))]
    public class PictureService: IPictureService
    {
        public async Task<IEnumerable<string>> Upload(List<IFormFile> pictures)
        {
            throw new System.NotImplementedException();
        }
    }
}