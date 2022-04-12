using System;
// It is our target class, which we are going to convert
interface ICelsiusWorker
{
    void GetTemperature();
}
// Imagine that it is third party library we have to adapt
class KelvinWorker
{
    public int GetTemperatureInKelvins()
    {
        // Imagine that it gets temperature from sensor or something
        return 300;
    }
}
class Adapter : ICelsiusWorker
{
    private readonly KelvinWorker _kelvinWorker;
    public void GetTemperature()
    {
        // Converting kelvin degrees to celsius degrees
        int celsiusTemperature = _kelvinWorker.GetTemperatureInKelvins() + 273;
        Console.WriteLine($"Temperature is {celsiusTemperature}");
    }
}
class Program
{
    static void Main()
    {
        ICelsiusWorker adapter = new Adapter();
        Console.WriteLine("Let's calculate internal energy of 100 moles of helium at the temperature of 30 C");
        adapter.GetTemperature();
    }
}