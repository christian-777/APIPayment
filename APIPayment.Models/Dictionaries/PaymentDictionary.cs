using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APiPayment.Services.Strategies;
using APIPayment.Models.Contracts;

namespace APIPayment.Models.Dictionaries
{
    public class PaymentDictionary
    {
        Dictionary<string, IStrategy> Types = new();

        public PaymentDictionary()
        {
            Types["CREDITO"] = new Credit();
            Types["DEBITO"] = new Debt();
            Types["PIX"] = new Pix();
            Types["BOLETO"] = new Ticket();
        }

        public IStrategy GetPaymentType(string payment)
        {
            return Types[payment.ToUpper()];
        }
    }
}
