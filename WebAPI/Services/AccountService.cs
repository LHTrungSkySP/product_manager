using AutoMapper;
using BanHang.Authorization;
using BanHang.Entities;
using BanHang.Helpers;
using BanHang.Models.Accounts;

namespace BanHang.Services
{
    public interface IAccountService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
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
        private readonly IJwtUtils _jwtUtils;

        public AccountService(BanHangContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
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
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Accounts.SingleOrDefault(x => x.AccountName == model.AccountName);
            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }

        public Account? GetById(int id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
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
                account = _mapper.Map<Account>(registerRequest);
                account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }
            else
                throw new AppException("Tên đăng nhập " + registerRequest.AccountName + " đã được sử dụng!");
        }

        public void Update(int id, UpdateRequest updateRequest)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
            {
                if (_context.Accounts.Any(ac => ac.AccountName == updateRequest.AccountName))
                {
                    throw new AppException("Đã tồn tại " + updateRequest.AccountName + " trong hệ thống!");
                }
                if (!string.IsNullOrEmpty(account.Password))
                {
                    account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateRequest.Password);
                }
                _mapper.Map(updateRequest, account);
                _context.Accounts.Update(account);
                _context.SaveChanges();
            }
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }

    }
}
