using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class DISCONT_GoodsREGULAR : IDiscountStrategy
    {
        public double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 2)
                discount = _quantity * _price * 0.03;
            return discount;
        }
    }
}
