abstract class Component
{
    public abstract void sendNotification(string message);
}
class Notifier : Component
{
    // Base sender by email
    public override void sendNotification(string message)
    {
        Console.WriteLine($"All employees recieved such email ''{message}'' ");
    }
}
class NotifierDecorator:Notifier
{
    private Notifier _notifier;
    public NotifierDecorator(Notifier notifier)
    {
        this._notifier = notifier;
    }
    public void SetNotifier(Notifier notifier)
    {
        _notifier = notifier;
    }
    public override void sendNotification(string message)
    {
        if(this._notifier != null)
        {
            _notifier.sendNotification(message);
        }
    }
}
class FacebookDecorator : NotifierDecorator
{
    public FacebookDecorator(Notifier notifier) : base(notifier)
    {
    }
    public override void sendNotification(string message) {
        base.sendNotification(message);
        Console.WriteLine($"All employees recieved such facebook message ''{message}''");
    }
}
class TelegramDecorator : NotifierDecorator
{
    public TelegramDecorator(Notifier notifier) : base(notifier)
    {
    }
    public override void sendNotification(string message)
    {
        base.sendNotification(message);
        Console.WriteLine($"All employees recieved such Telegram message ''{message}''");
    }
}
class VkDecorator : NotifierDecorator
{
    public VkDecorator(Notifier notifier) : base(notifier)
    {
    }
    public override void sendNotification(string message)
    {
        base.sendNotification(message);
        Console.WriteLine($"All employees recieved such Vk message ''{message}''");
    }
}
class Program
{
    static void Main()
    {
        Notifier mainNotifier = new Notifier();
        //turn on telegram and vk
        {
            TelegramDecorator tg = new TelegramDecorator(mainNotifier);
            VkDecorator vk = new VkDecorator(tg);
            Console.WriteLine("Sending notifications:");
            vk.sendNotification("Hello, world!");
        }
        //turn on facebook 
        {
            FacebookDecorator fb = new FacebookDecorator(mainNotifier);
            Console.WriteLine("Sending notifications:");
            fb.sendNotification("Hello, world!");
        }
        // email only
        {
            Console.WriteLine("Sending notifications:");
            mainNotifier.sendNotification("Hello, world!");
        }
        
    }
}