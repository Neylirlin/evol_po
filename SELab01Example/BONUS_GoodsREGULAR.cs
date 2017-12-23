using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class BONUS_GoodsREGULAR : IBonusStrategy
    {
        public int GetBonus(int _quantity, double _price)
        {
            int bonus = 0;
            if (_quantity * _price > 5000)
            {
                bonus = (int)(_quantity * _price * 0.07);
            }
            else
            {
                bonus = (int)(_quantity * _price * 0.05);
            }
            return bonus;
        }
    }
}
