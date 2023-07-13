using System;

class Program
{
    static void Main(string[] args)
    {

        Product product1 = new Product("Glasses","134673", 65 , 2);
        Product product2 = new Product("Jeans", "187473", 75, 1);
        Product product3 = new Product("Pencils", "628721", 1, 10);
        Product product4 = new Product("Shoes", "783245", 60, 1);
        Address address1 = new Address("786s 99w", "Orem", "Utah", "USA");
        Address address2 = new Address("19n 10E", "Rexburg", "Idaho", "USA");
        Address address3 = new Address("6s 4E", "Bountiful", "Utah", "USA");
        Address address4 = new Address("20s 1w", "Logan", "Utah", "USA");
        
        Customer customer1 = new Customer("Frank", address2);
        Customer customer2 = new Customer("Jena", address2);
        Customer customer3 = new Customer("Linda", address2);
        Customer customer4 = new Customer("Louise", address2);

        var order0 = new List<Product>();
            order0.Add(product1); 
        
        var jenaOrder = new List<Product>();
            jenaOrder.Add(product2);

        var lindaOrder = new List<Product>();
            lindaOrder.Add(product3); 

        var lousieOrder = new List<Product>();
            lousieOrder.Add(product4);

        Order order1 = new Order(order0, customer1, "Frank", "134673", 65, 2);
        Order order2 = new Order(jenaOrder, customer2, "jena", "187473", 75, 1);
        Order order3 = new Order(lindaOrder, customer3, "linda", "628721", 1, 10);
        Order order4 = new Order(lousieOrder, customer4, "lousie", "783245", 60, 1);

        DisplayOrder(order1);
        DisplayOrder(order2);
        DisplayOrder(order3);
        DisplayOrder(order4);


        static void DisplayOrder(Order order){
            System.Console.WriteLine(order.GetPackingLabel());
            System.Console.WriteLine(order.GetShippingLabel());
            System.Console.WriteLine($"Total: {order.PriceCalculator()}");


        }


    }
}

class Product {
    protected string _name;
    protected string _productID;
    protected double _price;
    protected int _quantity;

    public Product(string name, string productID, double price, int quantity){
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }
    public string Name {get => _name; set => _name = value;}
    public string ProductID {get => _productID; set => _productID = value;}
    public double Price {get => _price; set => _price = value;}
    public int Quantity{get => _quantity; set => _quantity = value;}

    public double PriceCalculator(){
        double _totalPrice = _price * _quantity;
        return _totalPrice;
    }

}

class Address{
    protected string _streetAddress;
    protected string _city;
    protected string _state;
    protected string _country; 

    public Address(string streetAddress, string city, string state, string country){
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;


    }

    public bool USAResident(){


        if(_country.ToUpper() == "USA"){
            return true;
        }
        else{
            return false;
        }
    }
    public string StreetAddress { get => _streetAddress; set => _streetAddress = value;} 
    public string City {get => _city; set => _city = value;}
    public string State {get => _state; set => _state = value;}
    public string Country {get => _country; set => _country = value;}

    public string GetAddress(){
        string address = $"{_streetAddress}, {_city}, {_state}, {_country}";

        return address;
    }
}

class Customer{
    protected string _name;
    protected Address _address;

    public Customer(string name, Address address){
        _name = name;
        _address = address;

    }
    public string Name {get => _name; set => _name = value;}
    public Address Address{get => _address; set => _address = value;}
    public bool USAResident(){
        return _address.USAResident();
    }

}

class Order: Product{
    protected List<Product> _products;
    protected Customer _customer;

    public Order(List<Product> products, Customer customers, string name, string productID, int price, int quantity): base(name, productID, price, quantity){
        _products = products;
        _customer = customers;
    }

    public void AddProduct(Product product){
        _products.Add(product);
    }

    public string GetPackingLabel(){
        
        string label = "Packing Label: ";
        foreach(Product line in _products){
            label += $"{line.Name}, ID: {line.ProductID}";
        }
        return label;
        
    }

    public string GetShippingLabel(){
        string list = $"Shipping Label: {_customer.Name} {_customer.Address.GetAddress()}";
       
        return list;
    }
    public double ShippingPrice(){
        if(_customer.USAResident() == false){
            return _price += 35;
        }
        else{
            return _price += 5;
        }      
    }
    public double TotalPrice(){
        return _price += ShippingPrice();
    }

}