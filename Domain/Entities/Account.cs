using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Account : BaseModel
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }

    }
}
