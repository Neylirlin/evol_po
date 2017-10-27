using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        #region FormationOfHeadersAndAccountElements
        public string GetHeader()
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
        }
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

        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = GetHeader();
            while (items.MoveNext())
            {
                Item each = (Item)items.Current;
                //определить сумму для каждой строки
                double discount = each.GetDiscount();
                int bonus = each.GetBonus();
                // сумма
                double thisAmount = each.getQuantity() * each.getPrice();
                // используем бонусы
                if ((each.getGoods().getPriceCode() ==
                Goods.REGULAR) && each.getQuantity() > 5)
                    discount +=
                    _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                if ((each.getGoods().getPriceCode() ==
                Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
                    discount =
                    _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                // учитываем скидку
                thisAmount =
                each.getQuantity() * each.getPrice() - discount;
                //показать результаты
                result += GetItemString(thisAmount, discount, bonus, each);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }

    }
}
