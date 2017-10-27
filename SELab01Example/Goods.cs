using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    // Класс, который представляет данные о товаре
    public abstract class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        private string title;

        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public Goods(string title)
        {
            this.title = title;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
        public abstract int GetBonus(int _quantity, double _price);
        public abstract double GetDiscount(int _quantity, double _price);
    }
}
