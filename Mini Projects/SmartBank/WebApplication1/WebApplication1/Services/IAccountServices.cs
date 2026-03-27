using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IAccountServices
    {
        AccountDto CreateAccount(CreateAccountDto dto);
        List<AccountDto> GetAll();
        AccountDto GetById(int id);
        void Deposit(TransactionDto dto);
        void Withdraw(TransactionDto dto);
    }
}
