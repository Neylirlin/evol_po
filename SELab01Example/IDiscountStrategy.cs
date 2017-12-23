namespace SELab01Example
{
    public interface IDiscountStrategy
    {
        double GetDiscount(int _quantity, double _price);
    }
}