using BanHang.Entities;
using BanHang.Models.Accounts;

namespace BanHang.Services
{
    public class UpdateRequest
    {
        public string? AccountName { get; set; }
        public string? Password { get; set; }
    }
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountById(string accountId);
        public void Register(RegisterRequest registerRequest);
        void Update(int id,UpdateRequest model);
        void Delete(int id);
    }
    public class AccountService : IAccountService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(string accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UpdateRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
