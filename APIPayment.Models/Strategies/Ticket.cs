using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Models.Contracts;

namespace APiPayment.Services.Strategies
{
    public class Ticket : IStrategy
    {
        double IStrategy.Pay(double value)
        {
            return value;
        }
    }
}
