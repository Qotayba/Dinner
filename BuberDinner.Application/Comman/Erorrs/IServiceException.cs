using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Comman.Erorrs
{
    public interface IServiceException
    {
         public HttpStatusCode StatusCode { get; }
         public string ErorrMessage { get; }
    }
}
