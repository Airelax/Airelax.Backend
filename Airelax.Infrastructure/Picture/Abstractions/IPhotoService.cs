using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Airelax.Infrastructure.Picture.Abstractions
{
    public interface IPictureService
    {
        Task<IEnumerable<string>> Upload(List<IFormFile> pictures);
    }
}