using BanHang.Models.Accounts;

namespace BanHang.Services
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
    }
    public interface IAccountService
    {
        public void Register(RegisterRequest registerRequest);
        void Update(UpdateRequest model);
        void Delete(int id);
    }
    public class AccountService : IAccountService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
