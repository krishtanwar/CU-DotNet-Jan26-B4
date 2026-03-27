using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly WebApplication1Context _context;

        public AccountRepository(WebApplication1Context context)
        {
            _context = context;
        }

        public Account Add(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
            return account;
        }

        public List<Account> GetAll()
        {
            return _context.Account.ToList();
        }

        public Account GetById(int id)
        {
            return _context.Account.Find(id);
        }

        public void Update(Account account)
        {
           
            _context.Account.Update(account);
            _context.SaveChanges();
        }
    }
}
