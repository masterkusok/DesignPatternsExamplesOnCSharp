interface ITransport
{
    string Deliver();
}
class Ship : ITransport
{
    public string Deliver()
    {
        return "*sounds of delivering something by SHIP";
    }
}
class Truck : ITransport
{
    public string Deliver()
    {
        return "*sounds of delivering something by TRUCK";
    }
}

abstract class Logistics
{
    abstract public ITransport CreateTransport();
    public void MakeDeliver()
    {
        Console.WriteLine(CreateTransport().Deliver());
    }
}

class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}
class LandLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}
class Client
{
    public void Main()
    {
        Console.WriteLine("Client says that he wants to make deliver by ship" +
            "so we use class SeaLogistics with method ClientCode and get his result:");
        ClientCode(new SeaLogistics());

        Console.WriteLine("Client says that he wants to make deliver by truck" +
            "so we use class LandLogistics with method ClientCode and get his result:");
        ClientCode(new LandLogistics());
    }

    private void ClientCode(Logistics logistics)
    {
        logistics.MakeDeliver();
    }
}
class Program
{
    static void Main()
    {
        new Client().Main();
    }
}
