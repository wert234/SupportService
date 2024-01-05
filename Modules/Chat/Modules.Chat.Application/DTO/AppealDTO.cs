using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.DTO
{
    public class AppealDTO
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public DateTime date { get; set; }
    }
}
