using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Commands
{
    public class CloseAppealsCommand(int appealId): IRequest<IActionResult>
    {
        public int AppealId { get; set; } = appealId;
    }
}
