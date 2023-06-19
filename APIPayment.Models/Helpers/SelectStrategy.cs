using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Models.Entities;
using APIPayment.Models.Strategies;

namespace APIPayment.Models.Helpers
{
    public static class SelectStrategy
    {
        public static object GetStrategy(this Payment payment)
        {
            try
            {
                var type = Type.GetType("APIPayment.Models.Strategies."+payment.PaymentForm, true, true);
                var constructor = type.GetConstructor(Type.EmptyTypes);
                object strategy= constructor.Invoke(new object[] { });
                return strategy;
            }
            catch(Exception ex) 
            {
                return ex;            
            }
        }
    }
}
