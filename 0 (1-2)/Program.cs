namespace Task0;

class C: Product{
    public C(string name, double price, double weight) : base(name,price,weight){

    }
};

class Program{
    public static void Main(string[]args){
        Buy buy = new Buy();
        Product a = new Product("a", 11,0.3);
        Product b = new Product("b",1,1);
        buy.addProduct(a);
        buy.addProduct(b);
        buy.addProduct(b);
        Check.showProduct(a);
        Check.showProduct(b);
        Check.showPurchase(buy);
    }
}