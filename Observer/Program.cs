// Publisher class
class YoutubeChannel
{
    private List<ISubscriber> _subscribers;
    private int _numberOfVideos;
    public int NumberOfVideos { get => _numberOfVideos; }
    public YoutubeChannel(int numberOfVideos)
    {
        _numberOfVideos = numberOfVideos;
        _subscribers = new List<ISubscriber>(); 
    }
    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
        Console.WriteLine($"{subscriber.GetName()} subscribed to channel!");
    }
    public void Unsubscribe(ISubscriber subscriber)
    {
        foreach(ISubscriber s in _subscribers)
        {
            if(s == subscriber)
            {
                Console.WriteLine($"Unsubscribed {subscriber.GetName()} successfully!");
                _subscribers.Remove(subscriber);
                return;
            }
        }
        Console.WriteLine($"No subscribers with name {subscriber.GetName()}");
    }
    public void AddNewVideo()
    {
        _numberOfVideos++;
        NotifySubscribers();
    }
    private void NotifySubscribers()
    {
        foreach(ISubscriber subscriber in _subscribers)
        {
            subscriber.CheckNewVideo(this);
        }
    }
}
// Observer or Subscriber Interface
interface ISubscriber
{
    void CheckNewVideo(YoutubeChannel channel);
    string GetName();
    void PrintInfo();
    int NumberOfCheckedVideos { get; }
}
// Usual subscriber can only watch videos
class UsualSubscriber : ISubscriber
{
    private int _numberOfCheckedVideos = 0;
    public int NumberOfCheckedVideos { get => _numberOfCheckedVideos; }
    private string _name;
    public UsualSubscriber(string name)
    {
        _name = name;
    }
    public void CheckNewVideo(YoutubeChannel channel)
    {
        _numberOfCheckedVideos++;
    }
    public string GetName()
    {
        return _name;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"This user checked {NumberOfCheckedVideos} videos");
    }
}
// Premium user can also download videos
class PremiumSubscriber : ISubscriber
{
    private string _name;
    private int _numberOfCheckedVideos;
    public int NumberOfCheckedVideos { get => _numberOfCheckedVideos; }
    public PremiumSubscriber(string name)
    {
        _name = name;
    }
    public void CheckNewVideo(YoutubeChannel channel)
    {
        _numberOfCheckedVideos++;
    }

    public string GetName()
    {
        return _name;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"This user checked and downloaded {_numberOfCheckedVideos} videos");
    }
}
class Program
{
    static void Main()
    {
        YoutubeChannel channel = new YoutubeChannel(10);
        UsualSubscriber usualSubscriber = new UsualSubscriber("Fedor");
        PremiumSubscriber premiumSubscriber = new PremiumSubscriber("Fernando");
        // 2 subscribers
        channel.Subscribe(usualSubscriber);
        channel.Subscribe(premiumSubscriber);
        channel.AddNewVideo();
        usualSubscriber.PrintInfo();
        premiumSubscriber.PrintInfo();
        // Usual subscriber canceled subscription
        channel.Unsubscribe(usualSubscriber);
        channel.AddNewVideo();
        usualSubscriber.PrintInfo();
        premiumSubscriber.PrintInfo();
    }
}