namespace Dau.Services.Seeding
{
    public interface ISeedingService
    {
        void SeedDormitoryData();
        void SeedFeatures();
        void SeedReviews();
        void SeedBookings();
        void SeedCartItems();
        void SeedRoomData();
        void seedDormitoryBlocks();
        void SeedDormitoryType();
        void SeedEMUMapLocations();
        void SeedSampleEmail();
        void SeedMessageTempletes();
        void SeedBackgroundSliderImages();
    }
}