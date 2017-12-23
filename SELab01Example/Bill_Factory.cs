using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    class Bill_Factory
    {
        public Goods Create(string type, string name)
        {
            IBonusStrategy bonus = null;
            IDiscountStrategy discount = null;
            Goods goods = null;
            switch (type)
            {
                case "REG":
                    {
                        bonus = new BONUS_GoodsREGULAR ();
                        discount = new DISCONT_GoodsREGULAR();
                        goods = new Goods(name, bonus, discount);
                    }
                    break;
                case "SAL":
                    {
                        bonus = new BONUS_GoodsSALE();
                        discount = new DISCONT_GoodsSALE();
                        goods = new Goods(name, bonus, discount);
                    }
                    break;
                case "SPO":
                    {
                        bonus = new BONUS_GoodsSPECIAL_OFFER();
                        discount = new DISCONT_GoodsSPECIAL_OFFER();
                        goods = new Goods(name, bonus, discount);
                    }
                    break;
            }
            return goods;
        }
    }
}
