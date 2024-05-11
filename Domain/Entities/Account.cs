using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Account : BaseModel
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}
