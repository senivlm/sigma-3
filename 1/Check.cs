namespace Task1;

static class Check{
    public static void showProduct(Product toShow){
        Console.WriteLine(toShow);
    }

    public static void showPurchase(Buy products){
        Console.WriteLine(
            $"Total amount: {products.totalAmount}\n"+ 
            $"Total weight: {products.totalWeight}kg\n"+
            $"Total price: {products.totalPrice}");
        foreach(var product in products.Purchases){
            Console.WriteLine(product);
        }
    }
}