interface IChair
{
    void ToSitOn();
}
interface ITable
{
    void ToPlaceThingsOn();
}
interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}
class VictorianChair : IChair
{
    public void ToSitOn()
    {
        Console.WriteLine("Sitting on chair in victorian style");
    }
}
class VictorianTable : ITable
{
    public void ToPlaceThingsOn()
    {
        Console.WriteLine("Putting things on table in victorian style");
    }
}
class ModernChair : IChair
{
    public void ToSitOn()
    {
        Console.WriteLine("Sitting on chair in modern style");
    }
}
class ModernTable : ITable
{
    public void ToPlaceThingsOn()
    {
        Console.WriteLine("Putting things on table in modern style");
    }
}
class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}
class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ITable CreateTable()
    {
        return new VictorianTable();
    }
}
class Client
{
    public void Main()
    {
        IFurnitureFactory furnitureFactory = new VictorianFurnitureFactory();
        Console.WriteLine("IFurnitureFactory contains example of VictorianFactory");
        furnitureFactory.CreateChair().ToSitOn();
        furnitureFactory.CreateTable().ToPlaceThingsOn();

        furnitureFactory = new ModernFurnitureFactory();
        Console.WriteLine("Same code but IFurnitureFactory contains example of ModernFactory");
        furnitureFactory.CreateChair().ToSitOn();
        furnitureFactory.CreateTable().ToPlaceThingsOn();
    }

}
class Program{
    static void Main(String[] args)
    {
        new Client().Main();
    }
}