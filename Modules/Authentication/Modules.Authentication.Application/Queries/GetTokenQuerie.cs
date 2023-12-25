using MediatR;
using Modules.Authentication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Queries
{
    public class GetTokenQuerie : IRequest<string>
    {
        public ApplicationUser User { get; set; }
    }
}
