using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Account : BaseModel
    {
        public string Name { get; set; }
        public int NumberWin { get; set; } = 0;
        public int NumberBattle { get; set; } = 0;
        public int NumberSteak { get; set; } = 0;
        public int Gold { get; set; } = 0;
    }
}
