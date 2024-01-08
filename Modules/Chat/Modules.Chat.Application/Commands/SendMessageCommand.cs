using MediatR;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Command
{
    public class SendMessageCommand : IRequest
    { 
        public int AppealId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}
