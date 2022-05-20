namespace Task0;

public enum MeatGrade : ushort {Highest = 10, Grade_1 = 5, Grade_2 = 3};
public enum MeatType {Mutton, Beef, Pork, Chicken};

class Meat: Product{

    public MeatGrade Grade {get; private set;}
    public MeatType Type {get; private set;}

    public Meat(string _name, double _price, double _weight, MeatGrade grade, MeatType type): base(_name, _price, _weight){
        Grade = grade;
        Type = type;
    }

    //shoud check for sign
    public override void changePrice(double percent)
    {
        Console.WriteLine($"Price change: {percent}%, additional: {(ushort)Grade}%");
        percent = percent < 0 ? percent - (ushort)Grade : percent + (ushort)Grade;
        base.changePrice(percent);
    }

    public override string ToString()
    {
        return $"[{base.ToString()}; Grade: {Grade}, Type: {Type}]";
    }

    public override bool Equals(object? obj)
    {
        var _meat = obj as Meat;
        if(_meat == null){
            return false;
        }
        return name == _meat.name && price == _meat.price && weight == _meat.weight && _meat.Grade == Grade && _meat.Type == Type;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, weight, price, Type, Grade);
    }
}