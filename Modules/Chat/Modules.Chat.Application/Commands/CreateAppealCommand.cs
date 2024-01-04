using MediatR;
using Modules.Chat.Application.DTO;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Command
{
    public class CreateAppealCommand : IRequest
    {
        public Appeal Appeal { get; set; }

        public CreateAppealCommand(AppealDTO appealDTO)
        {
            Appeal = new Appeal
            {
                Name = appealDTO.Name,
                UserId = appealDTO.UserId,
                Messages = new List<Message>
                {
                    new Message()
                    {
                        Appeal = Appeal,
                        Text = appealDTO.Message,
                        UserId= appealDTO.UserId,
                    }
                }
            };
        }
    }
}
