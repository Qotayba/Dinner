using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.Models
{
    public class Price
    {
        public decimal Amount {  get; private set; }
        public string Currency { get; private set;}

    }
}
