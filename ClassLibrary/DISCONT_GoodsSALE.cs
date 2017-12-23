using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class DISCONT_GoodsSALE : IDiscountStrategy
    {
        public double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity * _price > 2000)
                discount = _quantity * _price * 0.03;
            else if (_quantity > 3)
                discount = _quantity * _price * 0.01;
            return discount;
        }
    }
}
