﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class BillGenerator
    {
        IPresenter p;
        private List<Item> _items;
        public Customer _customer;
        public BillGenerator(Customer customer, IPresenter p)
        {
            _customer = customer;
            _items = new List<Item>();
            this.p = p;
        }

        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public double GetUsedBonus(Item each, double thisAmount, double discount)
        {
            double usedBonus = 0;
            if (each.getGoods().GetType() == typeof(Goods) && each.getQuantity() > 5)
            {
                usedBonus += _customer.useBonus((int)(thisAmount - discount));
            }
            if (each.getGoods().GetType() == typeof(BONUS_GoodsSPECIAL_OFFER) && each.getQuantity() > 1)
            {
                usedBonus += _customer.useBonus((int)(thisAmount - discount));
            }
            return usedBonus;
        }

        public string GenerateBill()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = p.GetHeader(_customer.getName());
            while (items.MoveNext())
            {
                double sum_with_discount = 0;
                double usedBonus = 0;
                double thisAmount = 0;
                Item each = items.Current;
                //определить сумму для каждой строки
                double discount = each.ExecuteOperationDiscount();
                int bonus = each.ExecuteOperationBonus();
                // сумма
                sum_with_discount = each.GetSum() - discount;
                usedBonus = GetUsedBonus(each, sum_with_discount, discount);
                thisAmount = sum_with_discount - usedBonus;
                //показать результаты
                result += p.GetItemString(thisAmount, discount, bonus, each);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += p.GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
        public IPresenter Preseter
        {
            get
            {
                return p;
            }
            set
            {
                p = value;

            }
        }
    }
}
