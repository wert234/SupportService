using MediatR;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Command
{
    public class AddAppealCommand(Appeal appeal) : IRequest
    {
        public Appeal Appeal { get; set; } = appeal;
    }
}
