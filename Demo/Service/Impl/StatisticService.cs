namespace Demo.Service.Impl;
using Demo.Model;
using Microsoft.EntityFrameworkCore;
using Demo.Service;
using System.Threading.Tasks;

public class StatisticService : IStatisticService
{
    private readonly DemoDbContext _context;

    public StatisticService(DemoDbContext context)
    {
        this._context = context;
    }

    public async Task<HomeData> GetHomeData()
    {
        var releasedCount = await _context.Products.Where(c=>c.IsRelease == true).CountAsync();
        var unReleasedCount = await _context.Products.Where(c=>c.IsRelease == false).CountAsync();
        var subscriptions = await _context.MailList.CountAsync();
        return new HomeData{ReleasedProduct=releasedCount, UnReleasedProduct=unReleasedCount, Subscription=subscriptions};
    }
}