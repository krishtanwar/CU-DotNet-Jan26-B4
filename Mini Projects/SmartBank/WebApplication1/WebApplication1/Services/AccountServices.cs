using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _repo;

        public AccountServices(IAccountRepository repo)
        {
            _repo = repo;
        }

        public AccountDto CreateAccount(CreateAccountDto dto)
        {
            if (dto.InitialDeposit < 1000)
                throw new BadRequestException("Minimum deposit is 1000");

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit,
                CreatedAt = DateTime.Now
            };

            var saved = _repo.Add(account);

            saved.AccountNumber = AccountNumberGenerator.Generate(saved.AccountId);

            _repo.Update(saved);

            return new AccountDto
            {
                AccountId = saved.AccountId,
                Name = saved.Name,
                Balance = saved.Balance,
                AccountNumber = saved.AccountNumber
            };
        }
        public List<AccountDto> GetAll()
        {
            var accounts = _repo.GetAll();
            var result = new List<AccountDto>();
            foreach(var a in accounts)
            {
                result.Add(new AccountDto
                {
                    AccountId = a.AccountId,
                    Name = a.Name,
                    Balance = a.Balance,
                    AccountNumber = a.AccountNumber
                });
            }

            return result;
        }

        public AccountDto GetById(int id)
        {
            var account = _repo.GetById(id);

            if (account == null)
                throw new NotFoundException("Account not found");

            return new AccountDto
            {
                AccountId = account.AccountId,
                Name = account.Name,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber
            };
        }

        public void Deposit(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = _repo.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;

            _repo.Update(account);
        }

        public void Withdraw(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = _repo.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance violation");

            account.Balance -= dto.Amount;

            _repo.Update(account);
        }
    }
}
