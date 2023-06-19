using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Models.Contracts;

namespace APiPayment.Services.Contexts
{
    public class StrategyContext
    { 
        public double ExecutePayment(IStrategy strategy, double value)
        {
            return strategy.Pay(value);
        }
    }
}
