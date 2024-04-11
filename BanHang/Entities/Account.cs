using System.ComponentModel.DataAnnotations;

namespace BanHang.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
    }
}
