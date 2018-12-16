namespace Dau.Services.Domain.HomeService
{
    public interface IGetHomeDormitoriesService
    {
        HomePageModel GetCoolOffersDeals(DormitoryPartialModel Model);
        HomePageModel GetHighlyRatedDormitories(DormitoryPartialModel Model);
        HomePageModel GetPopularDormitories(DormitoryPartialModel Model);
    }
}