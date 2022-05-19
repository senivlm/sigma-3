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

     public override string ToString()
    {
        return $"[Name: {name}; Price: ${price}; Weight: {weight}kg.]";
    }
}
