using greengrocer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace greengrocer.Checkout.Interfaces
{
    public interface IPaymentService
    {
        void PayOrder();
    }
}
