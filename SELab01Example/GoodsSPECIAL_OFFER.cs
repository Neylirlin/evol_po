using System;

namespace SELab01Example
{
    internal class GoodsSPECIAL_OFFER : Goods
    {
        public GoodsSPECIAL_OFFER(string title) : base(title)
        {
        }

        public override int GetBonus(int _quantity, double _price)
        {
            return 0;
        }

        public override double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 10)
                discount = (_quantity * _price) * 0.005;
            return discount;
        }
    }
}