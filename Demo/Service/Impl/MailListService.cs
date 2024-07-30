namespace Demo.Service.Impl;

using Demo.Model;
using Microsoft.EntityFrameworkCore;
using Demo.Service;
using System.Threading.Tasks;

public class MailListService : IMailListService
{
    private readonly DemoDbContext _context;

    public MailListService(DemoDbContext context)
    {
        _context = context;
    }

    public async Task<MailList> AddMail(MailList mail)
    {
        _context.MailList.Add(mail);
        await _context.SaveChangesAsync();
        return mail;
    }

    public async Task<PaginatedData<MailList>> GetAllMailList(QueryCondition query)
    {
        var dbQuery =  _context.MailList.Where(c=>c.Id>0);
        var count = await dbQuery.CountAsync();
        if(!string.IsNullOrWhiteSpace(query.OrderBy)) {
            dbQuery=dbQuery.OrderBy(query.OrderBy,query.IsDesc);
        }
        var mailList = await dbQuery
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
        return new PaginatedData<MailList>(mailList,query.PageIndex,count,query.PageSize);
    }
}