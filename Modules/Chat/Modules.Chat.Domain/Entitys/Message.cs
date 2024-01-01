
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Chat.Domain.Entitys
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int AppealId { get; set; }
        public Appeal Appeal { get; set; }
    }
}
