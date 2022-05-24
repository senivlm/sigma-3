namespace Task0;

static class Storage{
    private static List<Product> products = new List<Product>();

    public static void initProducts(){
        Product ribs = new Meat("ordinary_ribs", 10, 1.3, MeatGrade.Grade_2, MeatType.Beef);
        Product wagyu = new Meat("wahyu", 1000, 1, MeatGrade.Highest, MeatType.Beef);
        Product cheese = new Dairy_products("ordinary_cheese", 7, 1, 30);
        
        Product plate = new Product("plate", 3, 0.2);
        Product fork = new Product("fork", 0.5, 0.03);

        products = new List<Product>{ribs, wagyu, cheese, plate, fork};
    }

    public static List<Product> getAllProducts(Type type){
        return products.Where(product => product.GetType() == type).ToList();
    }

    public static void printAll(){
        foreach(Product product in products){
            Console.WriteLine(product);
        }
    }

    public static void changeAllPrices(double percent){
        List<Product> reserve = new List<Product>(products);
        foreach(Product product in products){
            try{
                product.changePrice(percent);
            }catch(ArgumentException){
                Console.WriteLine("Failed to change all prices. Transaction reversed.");
                products = reserve;
                return;
            }
        }
    }

    public static Product getByIndex(int index){
        if(products.Count < index - 1){
            throw new ArgumentException("index is too big");
        }
        return products[index];
    }

    public static void addProductDialog(){
        Console.WriteLine("Current cart: ");
        printAll();
        Console.WriteLine(
            "1) add new dairy product\n"+
            "2) add new Meat\n"+
            "3) add new product\n"+
            "type other key to exit");
        
        int choise = 0;
        int.TryParse(Console.ReadLine(), out choise);

        if(choise < 1 || choise > 4){
            return;
        }

        switch (choise){
            case 1:{
                try{
                    Dairy_products dp_product = getDialogDP();
                    products.Add(dp_product);
                    Console.WriteLine("dairy product was added");
                }catch(ArgumentException){
                    Console.WriteLine("failed to add new dairy product");
                }
                break;
            }
            case 2:{
                try{
                    Meat meat = getDialogMeat();
                    products.Add(meat);
                    Console.WriteLine("meat was added");
                }catch(ArgumentException){
                    Console.WriteLine("failed to add new meat");
                }
                break;
            }
            default: {
                try{
                    Product product = getDialogProduct();
                    products.Add(product);
                    Console.WriteLine("product was added");
                }catch(ArgumentException){
                    Console.WriteLine("failed to add new product");
                }
                break;
            }
        }
        
    }

    private static Product getDialogProduct(){
        string name;
        double price;
        double weight;
        Console.WriteLine("type product name: ");
        name = Console.ReadLine();
        if(name == string.Empty){
            Console.WriteLine("name can't be empty. defalut name was set");
            name = "default_name";
        }
        Console.WriteLine("type product price: ");
        double.TryParse(Console.ReadLine(), out price);
        Console.WriteLine("type product weight: ");
        double.TryParse(Console.ReadLine(), out weight);
        Product product = new Product(name, price, weight);
        return product;
    }

    private static Meat getDialogMeat(){
        string name;
        double price;
        double weight;
        MeatGrade grade;
        MeatType type;

        Console.WriteLine("type meat name: ");
        name = Console.ReadLine();
        if(name == string.Empty){
            Console.WriteLine("name can't be empty. defalut name was set");
            name = "default_name";
        }
        Console.WriteLine("type meat price: ");
        double.TryParse(Console.ReadLine(), out price);
        Console.WriteLine("type meat weight: ");
        double.TryParse(Console.ReadLine(), out weight);

        Console.WriteLine(
            "type meat grade:\n"+
            "1) Highest\n"+
            "2) Grade_1\n"+
            "3) Grade_2");

        int _grade = 0;
        int.TryParse(Console.ReadLine(), out _grade);

        if(_grade < 1 || _grade > 3){
            Console.WriteLine("there is no such grade. default(Grade_2) was chosen");
            _grade = 3;
        }

        switch(_grade){
            case 1: {
                grade = MeatGrade.Highest;
                break;
            }
            case 2:{
                grade = MeatGrade.Grade_1;
                break;
            }
            default:{
                grade = MeatGrade.Grade_2;
                break;
            }
        }

        Console.WriteLine(
            "type meat type:\n"+
            "1) Mutton\n"+
            "2) Beef\n"+
            "3) Pork\n"+
            "4) Chicken");

        int _type = 0;
        int.TryParse(Console.ReadLine(), out _type);

        if(_type < 1 || _type > 4){
            Console.WriteLine("there is no such grade. default(Chicken) was chosen");
            _type = 4;
        }

        switch(_type){
            case 1: {
                type = MeatType.Mutton;
                break;
            }
            case 2:{
                type = MeatType.Beef;
                break;
            }
            case 3:{
                type = MeatType.Pork;
                break;
            }
            default:{
                type = MeatType.Chicken;
                break;
            }
        }

        Meat meat = new Meat(name, price, weight, grade, type);
        return meat;
    }

    private static Dairy_products getDialogDP(){
        string name;
        double price;
        double weight;
        int expdate;
        Console.WriteLine("type dairy_Product name: ");
        name = Console.ReadLine();
        if(name == string.Empty){
            Console.WriteLine("name can't be empty. defalut name was set");
            name = "default_name";
        }
        Console.WriteLine("type dairy_Product price: ");
        double.TryParse(Console.ReadLine(), out price);
        Console.WriteLine("type dairy_Product weight: ");
        double.TryParse(Console.ReadLine(), out weight);
        Console.WriteLine("type expiration date: ");
        int.TryParse(Console.ReadLine(), out expdate);
        Dairy_products dairy_Products = new Dairy_products(name, price, weight, expdate);
        return dairy_Products;
    }
    
}