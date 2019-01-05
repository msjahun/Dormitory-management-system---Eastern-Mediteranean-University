using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dau.Services.Domain.ImageServices
{
    public interface IImageService
    {
        string ImageSplitter(string imageUrl, string imagePostfix);
        List<string> ImageSplitterList(List<string> imageUrls, string imagePostfix);
        bool RemoveImage(long CatalogImageId);
        Task<bool> UploadRoomImage(long RoomId);
    }
}