using BanHang.Entities;
using BanHang.Helpers;
using BanHang.Models.Accounts;

namespace BanHang.Services
{

    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        public void Register(RegisterRequest registerRequest);
        void Update(int id, UpdateRequest model);
        void Delete(int id);

        Account? GetById(int id);
    }
    public class AccountService : IAccountService
    {
        private BanHangContext _context;
        
        public AccountService(BanHangContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }

        public Account? GetById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public void Register(RegisterRequest registerRequest)
        {
            Account account = new Account();
            account.Id = _context.Accounts.Any() ? _context.Accounts.Max(acc => acc.Id) + 1 : 0;
            account.AccountName = registerRequest.AccountName;
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest updateRequest)
        {
            Account? account= _context.Accounts.Find(id); 
            if (account != null) 
            {
                account.AccountName = updateRequest.AccountName;
                account.Password = BCrypt.Net.BCrypt.HashPassword(updateRequest.Password);
                _context.Accounts.Update(account);
                _context.SaveChanges();
            }
        }
    }
}
