namespace Task0;
using System.Collections.Generic;
using System.Linq;

public class Buy
{
    private List<Product> purchases;
    public List<Product> Purchases 
    {
        get => purchases; 
        private set {purchases = value;}
    }
    public double totalPrice => Purchases.Sum(product => product.Price);
    public double totalWeight => Purchases.Sum(product => product.Price);
    public int totalAmount => Purchases.Count;
    public Buy()
    {
        purchases = new List<Product>();
    }

    public Buy(List<Product> products)
    {
        purchases = products;
    }

    public void addProduct(Product toAdd)
    {
        purchases.Add(toAdd);
    }

    public void removeProduct(Product toRemove)
    {
        purchases.Remove(toRemove);
    }
}