using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab01Example
{
    public interface IPresenter
    {
        string GetHeader(string Name);
        string GetFooter(double totalAmount, int totalBonus);
        string GetItemString(double thisAmount, double discount, int bonus, Item each);
    }
}
