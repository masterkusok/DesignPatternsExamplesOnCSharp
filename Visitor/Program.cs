abstract class Animal
{
    public string Name { get; private set; }
    public Animal(string name)
    {
        Name = name;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    abstract public void Accept(IVisitor visitor);
}
class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.ExecuteForDog(this);
    }
}
class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.ExecuteForCat(this);
    }
}
class Bird : Animal
{
    public Bird(string name) : base(name)
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.ExecuteForBird(this);
    }
}
interface IVisitor
{
    void ExecuteForBird(Bird bird);
    void ExecuteForDog(Dog dog);
    void ExecuteForCat(Cat cat);
}
class SoundVisitor : IVisitor
{
    public void ExecuteForBird(Bird bird)
    {
        Console.WriteLine($"Bird {bird.Name} says Tweet-tweet");
    }

    public void ExecuteForCat(Cat cat)
    {
        Console.WriteLine($"Cat {cat.Name} says meow-meow");
    }

    public void ExecuteForDog(Dog dog)
    {
        Console.WriteLine($"Dog {dog.Name} says Bark-bark");
    }
}
class EatVisitor : IVisitor
{
    public void ExecuteForBird(Bird bird)
    {
        Console.WriteLine($"Bird {bird.Name} eats seeds");
    }

    public void ExecuteForCat(Cat cat)
    {
        Console.WriteLine($"Cat {cat.Name} eats fish");
    }

    public void ExecuteForDog(Dog dog)
    {
        Console.WriteLine($"Dog {dog.Name} eats bones");
    }
}
class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Bird("Kiwi"));
        animals.Add(new Cat("Moorzick"));
        animals.Add(new Dog("Jack"));
        // Sound visitor
        foreach(Animal animal in animals)
        {
            animal.Accept(new SoundVisitor());
        }
        // Eating visitor
        foreach (Animal animal in animals)
        {
            animal.Accept(new EatVisitor());
        }
    }
}