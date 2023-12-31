using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Application.Common
{
    public static class ControllerHandle
    {
        public static IActionResult Resultchecking(object result, object desiredResult)
        {
            if (Equals(result, desiredResult))
                return new OkObjectResult(result);
            return new BadRequestResult();
        }
        public static IActionResult Resultchecking(object compared, object desiredResult, object result)
        {
            if (Equals(compared, desiredResult))
                return new OkObjectResult(result);
            return new BadRequestResult();
        }
    }
}
