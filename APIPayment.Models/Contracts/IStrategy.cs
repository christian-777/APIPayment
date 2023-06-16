using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPayment.Models.Contracts
{
    public interface IStrategy
    {
        double Pay(double value);
    }
}
