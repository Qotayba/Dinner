using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Error
    {
        public static class Authentication
        {
            public static ErrorOr.Error InvalidCredential = ErrorOr.Error.Conflict(
                code: "Auth.InvalidCredentail",
                description: "InvalidCredential");
        }
    }
}
