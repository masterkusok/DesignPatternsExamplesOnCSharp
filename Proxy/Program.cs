class User
{
    public int Id;
    public bool SubscriptionPurached;
    public User(int id, bool subscriptionPurached)
    {
        this.Id = id;
        this.SubscriptionPurached = subscriptionPurached;
    }
}
interface IServer
{
    void StreamMusic(User user);
}
class RealServer : IServer
{
    public void StreamMusic(User user)
    {
        Console.WriteLine($"Streaming some cool tracks to user id{user.Id}");
    }
}
class ProxyServer : IServer
{
    RealServer realServer;
    public ProxyServer()
    {
        realServer = new RealServer();
    }
    private bool CheckUserAccessToMusic(User user)
    {
        if (user.SubscriptionPurached)
        {
            Console.WriteLine($"Access allowed to user id{user.Id}");
            return true;
        }
        Console.WriteLine($"Access denied to user id{user.Id}");
        return false;
    }
    public void StreamMusic(User user)
    {
        if (CheckUserAccessToMusic(user))
        {
            realServer.StreamMusic(user);
            return;
        }
    }
}
class Program
{
    static void Main()
    {
        IServer server = new RealServer();
        User userWithoutSubscription = new User(12345, false);
        User userWithSubscription = new User(77777, true);

        // Working with server without proxy result
        Console.WriteLine("Without proxy\n");
        server.StreamMusic(userWithSubscription);
        server.StreamMusic(userWithoutSubscription);

        Console.WriteLine("\n////////////////////////////////\n////////////////////////////////\n");

        // Working with server with actual proxy
        Console.WriteLine("With proxy\n");
        server = new ProxyServer();
        server.StreamMusic(userWithSubscription);
        server.StreamMusic(userWithoutSubscription);

    }
}