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
            Goods goods = null;
            switch (type)
            {
                case "REG":
                    goods = new GoodsREGULAR(name);
                    break;
                case "SAL":
                    goods = new GoodsSALE(name);
                    break;
                case "SPO":
                    goods = new GoodsSPECIAL_OFFER(name);
                    break;
            }
            return goods;
        }
    }
}
