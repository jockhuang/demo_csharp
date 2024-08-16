using Demo.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Impl;

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

    public async Task<bool> DeleteMail(string email)
    {
        var itemToRemove = await _context.MailList.FirstOrDefaultAsync(x => x.Email == email);
        if (itemToRemove != null)
        {
            _context.MailList.Remove(itemToRemove);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public async Task<PaginatedData<MailList>> GetAllMailList(QueryCondition query)
    {
        var dbQuery = _context.MailList.Where(c => c.Id > 0);
        if (!string.IsNullOrWhiteSpace(query.Search))
            dbQuery = dbQuery.Where(c => c.Email.Contains(query.Search, StringComparison.OrdinalIgnoreCase));
        var count = await dbQuery.CountAsync();
        if (!string.IsNullOrWhiteSpace(query.OrderBy)) dbQuery = dbQuery.OrderBy(query.OrderBy, query.IsDesc);
        var mailList = await dbQuery
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
        return new PaginatedData<MailList>(mailList, query.PageIndex, count, query.PageSize);
    }
}