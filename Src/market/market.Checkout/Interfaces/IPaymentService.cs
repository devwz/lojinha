using market.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.Checkout.Interfaces
{
    public interface IPaymentService
    {
        void PayOrder();
    }
}
