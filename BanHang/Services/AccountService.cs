using AutoMapper;
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
        private readonly IMapper _mapper;

        public AccountService(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Delete(int id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }

        public Account? GetById(int id)
        {
            Account? account = _context.Accounts.Find(id);
            if(account != null)
            {
                return _context.Accounts.Find(id);
            }
            throw new AppException("Không tồn tại tài khoản này!");
        }

        public void Register(RegisterRequest registerRequest)
        {
            
            if (!_context.Accounts.Any(x => x.AccountName == registerRequest.AccountName))
            {
                Account account = new Account();
                account = _mapper.Map(registerRequest, account);
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }
            else
                throw new AppException("Tên đăng nhập " + registerRequest.AccountName + " đã được sử dụng!");
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
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
