interface IComponent
{
    int GetPrice();
}
class Product : IComponent
{
    private int _price;
    public Product(int price)
    {
        _price = price;
    }
    public int GetPrice()
    {
        return _price;
    }
}
class Box : IComponent
{
    private List<IComponent> _components = new List<IComponent>();
    public void Add(IComponent component)
    {
        _components.Add(component);
    }
    public void Remove(IComponent component)
    {
        _components.Remove(component);
    }
    public int GetPrice()
    {
        int price = 0;
        foreach (IComponent component in _components)
        {
            price += component.GetPrice();
        }
        return price;
    }
}

class Program
{
    static void Main()
    {
        // Main box which includes whole order
        Box orderBox = new Box();
        // Children boxes
        Box smallBox1 = new Box();
        Box smallBox2 = new Box();
        Box tinyBox = new Box();
        // Add some items to boxes 
        orderBox.Add(new Product(100));
        orderBox.Add(new Product(150));
        orderBox.Add(smallBox1);
        orderBox.Add(smallBox2);
        smallBox1.Add(new Product(15));
        smallBox1.Add(new Product(25));
        smallBox2.Add(tinyBox);
        smallBox2.Add(new Product(50));
        tinyBox.Add(new Product(1000));
        
        Console.WriteLine($"Nice order! Total price is {orderBox.GetPrice().ToString()}");
    }
}