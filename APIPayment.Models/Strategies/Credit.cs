using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Models.Contracts;

namespace APIPayment.Models.Strategies
{
    public class Credit : IStrategy 
    {
        double IStrategy.Pay(double value)
        {
            return value * 1.1;
        }
    }
}
