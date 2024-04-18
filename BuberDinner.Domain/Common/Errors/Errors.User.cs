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
        public static class User
        {
           public static ErrorOr.Error DuplicateEmail = ErrorOr.Error.Conflict(
           code: "User.Duplicate",
           description: "email already exist");
        }
       
    }
}
