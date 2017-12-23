using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public class TXTPresenter : IPresenter
    {
        public string GetHeader(string Name)
        {
            string result = "Счет для " + Name + "\n" + "\t" + "Название" + "\t" + "Цена" +
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
    }
}
