namespace Task0;
using System.Collections.Generic;
using System.Linq;

public class Buy
{
    public List<Product> Purchases 
    {
        get;
        private set;
    }
    public double totalPrice => Purchases.Sum(product => product.Price);
    public double totalWeight => Purchases.Sum(product => product.Weight);
    public int totalAmount => Purchases.Count;
    public Buy()
    {
        Purchases = new List<Product>();
    }

    public Buy(List<Product> products)
    {
        Purchases = products;
    }

    public void addProduct(Product toAdd)
    {
        Purchases.Add(toAdd);
    }

    public void removeProduct(Product toRemove)
    {
        Purchases.Remove(toRemove);
    }
}