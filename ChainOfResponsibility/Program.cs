// Intefrace of all the handlers
interface IHandler
{
    void HandleUserRequest(string request);
    IHandler SetNextHandler(IHandler nextHandler);
}
abstract class BaseHandler : IHandler
{
    protected IHandler _nextHandler;
    protected string _suitableRequest;
    public BaseHandler()
    {
        _suitableRequest = "";
    }
    // Returning IHandler here allows us to create chain in simple way like this:
    // handler1.SetNextHandler(handler2).SetNextHandler(handler3);
    public IHandler SetNextHandler(IHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return _nextHandler;
    }
    protected  bool CanHandleRequest(string request)
    {
        if (request == _suitableRequest)
        {
            return true;
        }
        return false;
    }
    public virtual void HandleUserRequest(string request)
    {
        if(_nextHandler != null)
            _nextHandler.HandleUserRequest(request);
    }

}
class Bot : BaseHandler
{
    public Bot()
    {
        _suitableRequest = "The most simple request";
    }
    public override void HandleUserRequest(string request)
    {
        if (CanHandleRequest(request))
        {
            Console.WriteLine($"I am {nameof(Bot)} and i am helping with your problem!\n");
        }
        else
        {
            Console.WriteLine("Sorry, I can't help you, redirecting you to the administrator");
            _nextHandler.HandleUserRequest(request);
        }
    }
}
class Administrator : BaseHandler
{
    public Administrator()
    {
        _suitableRequest = "Still simple request";
    }
    public override void HandleUserRequest(string request)
    {
        if (CanHandleRequest(request))
        {
            Console.WriteLine($"I am {nameof(Administrator)} and i am helping with your problem!\n");
        }
        else
        {
            Console.WriteLine("Sorry, I can't help you, redirecting you to the engineer");
            _nextHandler.HandleUserRequest(request);
        }
    }
}
class Engineer : BaseHandler
{
    public Engineer()
    {
        _suitableRequest = "Hard request";
    }
    public override void HandleUserRequest(string request)
    {
        if (CanHandleRequest(request))
        {
            Console.WriteLine($"I am {nameof(Engineer)} and i am helping with your problem!\n");
        }
        else
        {
            Console.WriteLine("Sorry, But no one can help you with your problem");
        }
    }
}
class Program
{
    static void Main()
    {
        IHandler bot = new Bot();
        IHandler admin = new Administrator();
        IHandler engineer = new Engineer();
        // In this line I create concrete sequence of handler for problem
        bot.SetNextHandler(admin).SetNextHandler(engineer);
        // Handling all type of requests
        Console.WriteLine("Trying to handle simple problem!");
        bot.HandleUserRequest("The most simple request");

        Console.WriteLine("\nTrying to handle a bit harder problem!");
        bot.HandleUserRequest("Still simple request");

        Console.WriteLine("\nTrying to handle hard problem!");
        bot.HandleUserRequest("Hard request");

        Console.WriteLine("\nTrying to handle not existing problem!");
        bot.HandleUserRequest("I love anime");
    }
}