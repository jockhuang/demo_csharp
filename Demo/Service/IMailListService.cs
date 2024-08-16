using Demo.Model;

namespace Demo.Service;

public interface IMailListService
{
    public Task<PaginatedData<MailList>> GetAllMailList(QueryCondition query);
    public Task<MailList> AddMail(MailList mail);

    public Task<bool> DeleteMail(string email);
}