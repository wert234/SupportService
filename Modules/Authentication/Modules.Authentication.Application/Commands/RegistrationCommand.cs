﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Commands
{
    public class RegistrationCommand : AuthenticationCommand
    {
        public string PasswordConfirm { get; set; }
    }
}
