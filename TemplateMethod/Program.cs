abstract class DrinkMaker
{
    public void MakeDrink()
    {
        BoilWater();
        PourWaterInCup();
        PutMainIngridient();
        Mix();
        PutOptionalIngridients();
        PrintDrinkIsReady();
    }
    abstract public void PrintDrinkIsReady();
    public void BoilWater()
    {
        Console.WriteLine("Boiling water...");
    }
    public void PourWaterInCup()
    {
        Console.WriteLine("Pouring boiled water right into a cup...");
    }
    abstract public void PutMainIngridient();
    public void Mix()
    {
        Console.WriteLine("Mixing...");
    }
    abstract public void PutOptionalIngridients();
}
class CoffeeMaker : DrinkMaker
{
    public override void PutMainIngridient()
    {
        Console.WriteLine("Putting coffee...");
    }
    public override void PutOptionalIngridients()
    {
        Console.WriteLine("Pouring milk...");
    }
    public override void PrintDrinkIsReady()
    {
        Console.WriteLine("Coffe is ready!");
    }
}
class TeaMaker : DrinkMaker
{
    public override void PutMainIngridient()
    {
        Console.WriteLine("Putting tea...");
    }
    public override void PutOptionalIngridients()
    {
        Console.WriteLine("Putting sugar...");
    }
    public override void PrintDrinkIsReady()
    {
        Console.WriteLine("Tea is ready!");
    }
}
class CocoaMaker : DrinkMaker
{
    public override void PutMainIngridient()
    {
        Console.WriteLine("Putting cocoa...");
    }
    public override void PutOptionalIngridients()
    {
        // No optional ingridients
    }
    public override void PrintDrinkIsReady()
    {
        Console.WriteLine("Cocoa is ready!");
    }
}
class Program
{
    static void Main()
    {
        DrinkMaker drinkMaker = new CocoaMaker();
        drinkMaker.MakeDrink();
        Console.WriteLine("\n");
        drinkMaker = new TeaMaker();
        drinkMaker.MakeDrink();
        Console.WriteLine("\n");
        drinkMaker = new CoffeeMaker();
        drinkMaker.MakeDrink();


    }
}