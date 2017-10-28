using System;
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
        public BillGenerator(Customer customer)
        {
            _customer = customer;
            _items = new List<Item>();
        }

        public BillGenerator(Customer customer, IPresenter p) : this(customer)
        {
            this.p = p;
        }

        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        #region FormationOfHeadersAndAccountElements
/*        public string GetHeader()
        {
            string result = "Счет для " + _customer.getName() + "\n" + "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            string result = "Сумма счета составляет " + totalAmount.ToString() + "\n" + "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
        }

        public string GetItemString(double thisAmount, double discount, int bonus, Item each)
        {
            string result = "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + each.GetSum().ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
            return result;
        }*/
        #endregion

        public double GetUsedBonus(Item each, double thisAmount, double discount)
        {
            double usedBonus = 0;
            if (each.getGoods().GetType() == typeof(GoodsREGULAR) && each.getQuantity() > 5)
            {
                usedBonus += _customer.useBonus((int)(thisAmount - discount));
            }
            if (each.getGoods().GetType() == typeof(GoodsSPECIAL_OFFER) && each.getQuantity() > 1)
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
                double discount = each.GetDiscount();
                int bonus = each.GetBonus();
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
    }
}
