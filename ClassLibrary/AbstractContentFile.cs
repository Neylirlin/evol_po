using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SELab01Example
{
    public abstract class AbstractContentFile
    {
        public string CreateBill()
        {
            StreamReader stream_reader = SetSource();
            string name = GetCustomer(stream_reader);
            int bonus = GetBonus(stream_reader);
            Customer customer = new Customer(name, bonus);
            IPresenter p = new TXTPresenter();
            BillGenerator b = new BillGenerator(customer, p);
            int goodsQty = GetGoodsCount(stream_reader);
            Goods[] goods = new Goods[goodsQty];
            GetNextGood(goods, stream_reader);
            int itemsQty = GetItemsCount(stream_reader);
            GetNextItem(itemsQty, stream_reader, b, goods);
            string bill = b.GenerateBill();
            return bill;
        }

        public abstract StreamReader SetSource();
        public abstract string GetCustomer(StreamReader stream_reader);
        public abstract int GetBonus(StreamReader stream_reader);
        public abstract int GetGoodsCount(StreamReader stream_reader);
        public abstract void GetNextGood(Goods[] goods, StreamReader stream_reader);
        public abstract int GetItemsCount(StreamReader stream_reader);
        public abstract void GetNextItem(int itemsQty, StreamReader stream_reader, BillGenerator b, Goods[] goods);
    }
}
