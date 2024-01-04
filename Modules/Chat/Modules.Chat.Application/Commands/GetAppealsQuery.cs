using MediatR;
using Modules.Chat.Application.DTO;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Commands
{
    public class GetAppealsQuery(int UserId) : IRequest<IEnumerable<AppealDTO>>
    {
        public int UserId { get; set; } = UserId;
    }
}
