using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BanHang.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
