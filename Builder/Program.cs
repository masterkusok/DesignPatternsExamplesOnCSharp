interface IHouseBuilder
{
    void Reset();
    House GetHouse();
    void BuildWalls();
    void BuildWindows();
    void BuildPool();
    void BuildFence();
}
class WoodenHouseBuilder : IHouseBuilder
{
    private House _house = new House();
    public void BuildFence()
    {
        _house.Add("wooden pool");
    }

    public void BuildPool()
    {
        _house.Add("wooden pool");
    }

    public void BuildWalls()
    {
        _house.Add("wooden walls");
    }

    public void BuildWindows()
    {
        _house.Add("wooden windows");
    }

    public House GetHouse()
    {
        return this._house;
    }

    public void Reset()
    {
        this._house = new House();
    }
}

class StoneHouseBuilder : IHouseBuilder
{
    private House _house = new House();
    public void BuildFence()
    {
        _house.Add("stone pool");
    }

    public void BuildPool()
    {
        _house.Add("stone pool");
    }

    public void BuildWalls()
    {
        _house.Add("stone walls");
    }

    public void BuildWindows()
    {
        _house.Add("stone windows");
    }
    public House GetHouse()
    {
        return _house;
    }
    public void Reset()
    {
        this._house = new House();
    }
}
class Director
{
    private IHouseBuilder _builder;
    public IHouseBuilder Builder
    {
        set { _builder = value; }
    }
    public Director(IHouseBuilder builder)
    {
        Builder = builder;
    }
    public void BuildHouseWithPool()
    {
        _builder.BuildWindows();
        _builder.BuildWalls();
        _builder.BuildFence();
        _builder.BuildPool();
    }
    public void BuildHouseWithoutPool()
    {
        _builder.BuildWindows();
        _builder.BuildWalls();
        _builder.BuildFence();
        _builder.BuildPool();
    }
}
class House
{
    private List<string> _houseParts = new List<string>();
    public void Add(string part)
    {
        _houseParts.Add(part);
    }
    public void WritePartsInConsole()
    {
        string allHouseParts = "";
        foreach (string part in _houseParts)
        {
            allHouseParts += $"{part}, ";
        }
        Console.WriteLine(allHouseParts);
    }

}
class Program
{
    static void Main()
    {
        StoneHouseBuilder stoneHouseBuilder = new StoneHouseBuilder();
        WoodenHouseBuilder woodenHouseBuilder = new WoodenHouseBuilder();

        Director director = new Director(stoneHouseBuilder);
        Console.WriteLine("Making code with StoneHouseBuilder: ");
        director.BuildHouseWithPool();
        director.BuildHouseWithoutPool();
        stoneHouseBuilder.GetHouse().WritePartsInConsole();

        director = new Director(woodenHouseBuilder);
        Console.WriteLine("Making same code with WoodenHouseBuilder: ");
        director.BuildHouseWithPool();
        director.BuildHouseWithoutPool();
        woodenHouseBuilder.GetHouse().WritePartsInConsole();
    }
}