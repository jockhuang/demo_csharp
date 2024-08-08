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
        var releasedCount = 0;
        var unReleasedCount = 0;
        var products = await _context.Products.GroupBy(c=>c.IsRelease).Select(g => new { name = g.Key, count = g.Count() }).ToListAsync();
        foreach(var row in products){
            if(row.name){
                releasedCount = row.count;
            }else{
                unReleasedCount = row.count;
            }
        }
        var subscriptions = await _context.MailList.CountAsync();
        return new HomeData{ReleasedProduct=releasedCount, UnReleasedProduct=unReleasedCount, Subscription=subscriptions};
    }
}