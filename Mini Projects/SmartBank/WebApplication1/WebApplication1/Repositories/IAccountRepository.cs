using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IAccountRepository
    {
        Account Add(Account account);
        List<Account> GetAll();
        Account GetById(int id);
        void Update(Account account);
    }
}
