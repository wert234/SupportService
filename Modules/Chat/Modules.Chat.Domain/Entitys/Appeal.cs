using Modules.Chat.Domain.Enums;

namespace Modules.Chat.Domain.Entitys
{
    public class Appeal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<Message> Messages { get; set; } = Enumerable.Empty<Message>();
        public Status Status { get; set; } = Status.Creaded;
    }
}
