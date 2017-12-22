using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SELab01Example
{
    class YAMLFile : AbstractContentFile
    {
        public override StreamReader SetSource(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];
            FileStream file_stream = new FileStream(filename, FileMode.Open);
            StreamReader stream_reader = new StreamReader(file_stream);
            return stream_reader;
        }
        public override string GetCustomer(StreamReader stream_reader)
        {
            string line = GetNextLine(stream_reader);
            string[] result = line.Split(':');
            string name = result[1].Trim();
            return name;
        }
        public override int GetBonus(StreamReader stream_reader)
        {
            string line = GetNextLine(stream_reader);
            string[] result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            return bonus;
        }
        public override int GetGoodsCount(StreamReader stream_reader)
        {
            string line = GetNextLine(stream_reader);
            string[] result = line.Split(':');
            int goodsQty = Convert.ToInt32(result[1].Trim());
            return goodsQty;
        }
        public override void GetNextGood(Goods[] goods, StreamReader stream_reader)
        {
            string[] result;
            string line;
            for (int i = 0; i < goods.Length; i++)
            {
                do
                {
                    line = GetNextLine(stream_reader);
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();
                Bill_Factory factory = new Bill_Factory();
                goods[i] = factory.Create(type, result[0]);
            }
        }
        public override int GetItemsCount(StreamReader stream_reader)
        {
            string[] result;
            string line;
            do
            {
                line = GetNextLine(stream_reader);
            } while (line.StartsWith("#"));
            result = line.Split(':');
            int itemsQty = Convert.ToInt32(result[1].Trim());
            return itemsQty;
        }
        public override void GetNextItem(int itemsQty, StreamReader stream_reader, BillGenerator bill_1, Goods[] goods)
        {
            string[] result;
            string line;
            for (int i = 0; i < itemsQty; i++)
            {
                do
                {
                    line = GetNextLine(stream_reader);
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                int gid = Convert.ToInt32(result[0].Trim());
                double price = Convert.ToDouble(result[1].Trim());
                int qty = Convert.ToInt32(result[2].Trim());
                bill_1.addGoods(new Item(goods[gid - 1], qty, price));
            }
        }

        public string GetNextLine(StreamReader sr)
        {
            string line = sr.ReadLine();
            return line;
        }
    }
}
