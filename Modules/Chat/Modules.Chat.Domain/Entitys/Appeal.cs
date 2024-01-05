﻿using Modules.Chat.Domain.Enums;
using System;

namespace Modules.Chat.Domain.Entitys
{
    public class Appeal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Message> Messages { get; set; }
        public Status Status { get; set; } = Status.Creaded;
        public DateTime date { get; set; } = DateTime.Now;
    }
}
