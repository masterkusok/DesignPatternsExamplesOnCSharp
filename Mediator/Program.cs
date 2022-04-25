class TransferEventArgs: EventArgs
{
    public string RecieverName { get; set; }
    public int Sum { get; set; }
    public TransferEventArgs(string recieverName, int sum)
    {
        RecieverName = recieverName;
        Sum = sum;
    }
}
class BankClient
{
    public string Name { get; set; }
    public int Capital { get; private set; }
    private Bank mediator;
    public BankClient(string name, int startCapital, Bank bank)
    {
        Name = name;
        Capital = startCapital;
        mediator = bank;
        mediator.TransferEventHandler += RecieveTransferedMoney;
    }
    private void RecieveTransferedMoney(object sender, TransferEventArgs args)
    {
        if (args.RecieverName == Name)
        {
            Capital += args.Sum;
            Console.WriteLine($"Money recieved successfully, you have {Capital}$ on your account");
        }
    }
    public void MakeTransfer(string recieverName, int sum)
    {
        if (Capital - sum >= 0)
        {
            Capital -= sum;
            mediator.TransferMoney(new TransferEventArgs(recieverName, sum));
        }
        else
        {
            Console.WriteLine($"Error, not enough money on {Name}'s account");
        }
    }
}
// In this example - bank is mediator between two clients
class Bank
{
    public event EventHandler<TransferEventArgs>? TransferEventHandler;
    private List<BankClient> _clients = new List<BankClient>();
    public void TransferMoney(TransferEventArgs args)
    {
        TransferEventHandler?.Invoke(this, args);
    }
    public void RegisterNewClient(BankClient client)
    {
        _clients.Add(client);
    }
    public void UnregisterClient(string name)
    {
        foreach(BankClient client in _clients)
        {
            if(client.Name == name)
            {
                _clients.Remove(client);
                break;
            }
        }
    }
    
}
class Program
{
    static void Main()
    {
        Bank bank = new Bank();
        BankClient oleg = new BankClient("Oleg", 1000, bank);
        BankClient denis = new BankClient("Denis", 500, bank);
        Console.WriteLine($"Before transfer: Oleg - {oleg.Capital}$, Denis - {denis.Capital}$");
        oleg.MakeTransfer("Denis", 500);
        Console.WriteLine($"After transfer: Oleg - {oleg.Capital}$, Denis - {denis.Capital}$");
    }
}