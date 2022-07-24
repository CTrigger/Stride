using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFileService
    {
        public Task SaveImageAsync(IFormFile content, FileMode fileMode);
    }
}
