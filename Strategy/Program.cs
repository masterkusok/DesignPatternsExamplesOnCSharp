class Navigator
{
    private IRouteBuildStrategy _strategy;
    public Navigator(IRouteBuildStrategy strategy)
    {
        _strategy = strategy;
    }
    public void SetStrategy(IRouteBuildStrategy strategy)
    {
        _strategy = strategy;
    }
    public void BuildRoute(string pointA, string pointB)
    {
        _strategy.BuildRoute(pointA, pointB);
    }
}
interface IRouteBuildStrategy
{
    void BuildRoute(string pointA, string pointB);
}
class CarRouteBuildStrategy : IRouteBuildStrategy
{
    public void BuildRoute(string pointA, string pointB)
    {
        Console.WriteLine($"Route from {pointA} to {pointB} by highways");
    }
}
class WalkerRouteBuildStrategy : IRouteBuildStrategy
{
    public void BuildRoute(string pointA, string pointB)
    {
        Console.WriteLine($"Route from {pointA} to {pointB} by pedestrianized streets");
    }
}
class TrainRouteBuildStrategy : IRouteBuildStrategy
{
    public void BuildRoute(string pointA, string pointB)
    {
        Console.WriteLine($"Route from {pointA} to {pointB} by railways");
    }
}
class Program
{
    static void Main()
    {
        Navigator navigator = new Navigator(new WalkerRouteBuildStrategy());
        navigator.BuildRoute("Rome", "Moscow");
        navigator.SetStrategy(new CarRouteBuildStrategy());
        navigator.BuildRoute("Paris", "Berlin");
        navigator.SetStrategy(new TrainRouteBuildStrategy());
        navigator.BuildRoute("Beijing", "Tokyo");
    }
}