﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace SELab01Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            // read customer
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();
            // read bonus
            line = sr.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            Customer customer = new Customer(name, bonus);
            IPresenter p = new TXTPresenter();
            BillGenerator b = new BillGenerator(customer, p);
            // read goods count
            line = sr.ReadLine();
            result = line.Split(':');
            int goodsQty = Convert.ToInt32(result[1].Trim());
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                // Пропустить комментарии
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();
                Goods t = null;
                switch (type)
                {
                    case "REG":
                        t = new GoodsREGULAR(result[0]);
                        break;
                    case "SAL":
                        t = new GoodsSALE(result[0]);
                        break;
                    case "SPO":
                        t = new GoodsSPECIAL_OFFER(result[0]);
                        break;
                }
                g[i] = t;
            }
            // read items count
            // Пропустить комментарии
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            result = line.Split(':');
            int itemsQty = Convert.ToInt32(result[1].Trim());
            for (int i = 0; i < itemsQty; i++)
            {
                // Пропустить комментарии
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                int gid = Convert.ToInt32(result[0].Trim());
                double price = Convert.ToDouble(result[1].Trim());
                int qty = Convert.ToInt32(result[2].Trim());
                b.addGoods(new Item(g[gid - 1], qty, price));
            }
            string bill = b.GenerateBill();
            Console.WriteLine(bill);
            Console.ReadKey();
        }
    }
}
