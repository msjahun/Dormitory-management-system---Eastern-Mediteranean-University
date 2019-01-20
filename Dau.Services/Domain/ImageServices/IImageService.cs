using System.Collections.Generic;

namespace Dau.Services.Domain.ImageServices
{
    public interface IImageService
    {
        string ImageSplitter(string imageUrl, string imagePostfix);
        List<string> ImageSplitterList(List<string> imageUrls, string imagePostfix);
        bool RemoveImage(long CatalogImageId);
        bool uploadDormitoryImage(long DormitoryId);
        bool uploadDormitoryLogoImage(long DormitoryId);
        bool UploadRoomImage(long RoomId);
        string PrepareImageForMobileApi(string imageUrl);
        List<string> PrepareImageForMobileApi(List<string> imageUrls);
        bool uploadBookingReceiptImage(long BookingId);
        bool UploadFeatureImage(long id);
    }
}