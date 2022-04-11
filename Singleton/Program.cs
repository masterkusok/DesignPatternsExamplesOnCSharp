sealed class Singleton{
    private string _value { get; set; }
    private static Singleton _instance;
    private Singleton(string value)
    {
        _value = value;
    }
    private static readonly object _locker = new object();
    // This version of GetInstance method can be used in single thread code
    // but it is dangerous to use it in multi-thread code
    /*
    public static Singleton GetInstance(string value)
    {
        if(_instance == null)
        {
            _instance = new Singleton(value);
        }
        return _instance;
    }
    */
    // Multi-thread safe version of GetInstance()
    public static Singleton GetInstance(string value)
    {
        if (_instance == null)
        {
            lock (_locker)
            {
                if(_instance == null)
                {
                    _instance = new Singleton(value);
                }
            }
        }
        return _instance;
    }
    public string GetValue()
    {
        return _value;
    }
}
class Program
{
    static private void TestSingleThreadCode()
    {
        Console.WriteLine("Testing single thread code!");
        Singleton firstSingleton = Singleton.GetInstance("First!");
        Singleton secondSingleton = Singleton.GetInstance("Second!");
        Console.WriteLine($"First singleton value - {firstSingleton.GetValue()} \n" +
            $"Second singleton value - {secondSingleton.GetValue()}");
    }

    static private void TestMultiThreadCode()
    {
        Console.WriteLine("Testing multi thread code!");

        Thread thread1 = new Thread(()=>{
            Singleton firstSingleton = Singleton.GetInstance("First!");
            Console.WriteLine($"Singleton value - {firstSingleton.GetValue()}");
        });

        Thread thread2 = new Thread(() => {
            Singleton secondSingleton = Singleton.GetInstance("Second!");
            Console.WriteLine($"Singleton value - {secondSingleton.GetValue()}");
        });
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    static void Main()
    {
        TestMultiThreadCode();
    }
}