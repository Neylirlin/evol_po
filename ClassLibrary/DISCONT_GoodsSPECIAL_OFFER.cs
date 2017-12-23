using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class DISCONT_GoodsSPECIAL_OFFER : IDiscountStrategy
    {
        public double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity * _price > 5000)
                discount = _quantity * _price * 0.05;
            else if (_quantity > 10)
                discount = _quantity * _price * 0.005;
            return discount;
        }
    }
}
