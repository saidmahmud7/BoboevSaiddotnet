interface IProduct
{
    decimal GetPrice();
}

interface IDiscountableProduct : IProduct
{
    decimal GetDiscountPrice();
}

class Product : IDiscountableProduct
{
    public virtual decimal GetPrice()
    {
        return 100; 
    }

    public virtual decimal GetDiscountPrice()
    {
        return GetPrice() * 0.9m;
    }
}


class DigitalProduct : IProduct
{
    public decimal GetPrice()
    {
        return 100; 
    }
}