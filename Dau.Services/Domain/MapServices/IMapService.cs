namespace Dau.Services.Domain.MapServices
{
    public interface IMapService
    {
        string GetMapSectionById(long id);
        string GetLatitudeLongitudeBySectionId(long id);
        string GetMapSectionNameById(long id);
    }
}