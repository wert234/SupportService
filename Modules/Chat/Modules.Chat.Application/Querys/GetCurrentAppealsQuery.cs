using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.DTO;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Querys
{
    public class GetCurrentAppealsQuery(int UserId) : IRequest<IActionResult>
    {
        public int UserId { get; set; } = UserId;
    }
}
