using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Modules.Chat.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Hubs
{
  //  [Authorize(Roles = "user")]
    public class ChatHub : Hub
    {

    }
}
