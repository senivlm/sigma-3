using Task1;

class Program{
    public static void Main(string[]args){
       foodTask();
    }
    private static void foodTask(){
        Product a = new Product("a", 11,0.3);
        Product b = new Product("b",1,1);
        Buy buy = new Buy();
        buy.addProduct(a);
        buy.addProduct(b);
        buy.addProduct(b);
        Check.showPurchase(buy);
        Console.WriteLine("---------------------\n" + "changePrice(30)\n" + "---------------------");
        a.changePrice(30);
        Check.showPurchase(buy);
    }
}