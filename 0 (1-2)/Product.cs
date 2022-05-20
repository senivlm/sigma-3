namespace Task0;
//aka IProduct
public class Product {
    protected string name;
    protected double price; 
    //kilograms
    protected double weight;

    public string Name{
        get => name;
        set {
            if(value == null || value == string.Empty){
                throw new ArgumentException("Name can't be empty");
            }else{
                name = value;
            }
        }
    }
    public double Price {
        get => price;

        set{
            if(value > 0){
                price = value;
            }else{
                throw new ArgumentException("Price can't be negative");
            }
        }
    }

    public double Weight{
        get => weight;

        set{
            if(value > 0){
                weight = value;
            }else{
                throw new ArgumentException("Price can't be negative");
            }
        }
    }

    public Product(string _name, double _price, double _weight){
        Name = _name;
        Price = _price;
        Weight = _weight;
    }

    public virtual void changePrice(double percent){
        if(percent > 100 || percent < -100){
            throw new ArgumentException("price can't be negative");
        }
        price += price * 0.01 * percent;
    }

     public override string ToString()
    {
        return $"[Name: {name}; Price: ${price}; Weight: {weight}kg.]";
    }

    public override bool Equals(object? obj)
    {
        var _product = obj as Product;
        if(_product == null){
            return false;
        }
        return name == _product.name && price == _product.price && weight == _product.weight;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, weight, price);
    }

    //Unlike the Equals method and the equality operator, the ReferenceEquals method cannot be overridden
    //https://docs.microsoft.com/en-us/dotnet/api/system.object.referenceequals?view=net-6.0

    //The C# compiler does not allow you to override the Finalize method.
    //https://docs.microsoft.com/en-us/dotnet/api/system.object.finalize?view=net-6.0

    //GetType is not virtual
}
