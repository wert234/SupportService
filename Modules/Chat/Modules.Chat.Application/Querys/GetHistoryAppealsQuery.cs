using MediatR;
using Modules.Chat.Application.DTO;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Querys
{
    public class GetHistoryAppealsQuery(int UserId) : IRequest<IEnumerable<AppealDTO>>
    {
        public int UserId { get; set; } = UserId;
    }
}
