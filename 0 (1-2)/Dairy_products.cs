namespace Task0;

class Dairy_products : Product{
    public int ExpDate {get; private set;}
    public Dairy_products(string _name, double _price, double _weight, int expDate): base(_name, _price, _weight){
        if(expDate < 1) {
            throw new ArgumentException($"unstorable: expiration date = {expDate}day(s)");
        }
        ExpDate = expDate;
    }

    public override void changePrice(double percent)
    {
        ushort delta;
        if(ExpDate < 7){
            delta = 40;
        }else if(ExpDate < 14){
            delta = 20;
        }else if(ExpDate < 30){
            delta = 10;
        }else{
            delta = 0;
        }
        Console.WriteLine($"Price change: {percent}%, additional: {delta}%");
        percent = percent < 0? percent - delta : percent + delta;

        base.changePrice(percent);
    }

    public override string ToString()
    {
        return $"[{base.ToString()}; ExpDate: {ExpDate}day(s)]";
    }

    public override bool Equals(object? obj)
    {
        var _product = obj as Dairy_products;
        if(_product == null){
            return false;
        }
        return name == _product.name && price == _product.price && weight == _product.weight && _product.ExpDate == ExpDate;
    }

    public override int GetHashCode()
    {
         return HashCode.Combine(name, weight, price, ExpDate);
    }
}