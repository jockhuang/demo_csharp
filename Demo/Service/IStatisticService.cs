using Demo.Model;

namespace Demo.Service;

public interface IStatisticService
{
    public Task<HomeData> GetHomeData();
}
