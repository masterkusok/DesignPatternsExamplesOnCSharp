interface IOsLogic
{
    void OpenTextFile();
    void OpenCmd();
}
class LinuxOsLogic : IOsLogic
{
    public void OpenCmd()
    {
        Console.WriteLine("Linux cmd is opened");
    }

    public void OpenTextFile()
    {
        Console.WriteLine("Text file was opened on Linux");
    }
}
class WindowsOsLogic : IOsLogic
{
    public void OpenCmd()
    {
        Console.WriteLine("Windows cmd is opened");
    }

    public void OpenTextFile()
    {
        Console.WriteLine("Text file was opened on Windows");
    }
}
abstract class GraphicUserInterface
{
    protected IOsLogic _osLogic;
    public GraphicUserInterface(IOsLogic osLogic)
    {
        _osLogic = osLogic;
    }
    protected void OpenTextFileFromCmd()
    {
        _osLogic.OpenCmd();
        _osLogic.OpenTextFile();
    }
    abstract public void OpenTextFile();
}
class AdminGui : GraphicUserInterface
{
    public AdminGui(IOsLogic osLogic) : base(osLogic)
    {
        _osLogic = osLogic;
    }

    public override void OpenTextFile()
    {
        Console.WriteLine("We are using admin gui now");
        OpenTextFileFromCmd();
    }
}
class UserGui : GraphicUserInterface
{
    public UserGui(IOsLogic osLogic) : base(osLogic)
    {
        _osLogic = osLogic;
    }
    public override void OpenTextFile()
    {
        Console.WriteLine("We are using user gui now");
        OpenTextFileFromCmd();
    }
}
class Program
{
    static void Main()
    {
        GraphicUserInterface gui = new UserGui(new LinuxOsLogic());
        Console.WriteLine("Welcome to cross platfrom app, common user! \n starting on Linux...");
        gui.OpenTextFile();
        Console.WriteLine("starting on Windows...");
        gui = new UserGui(new WindowsOsLogic());
        gui.OpenTextFile();

        Console.WriteLine("\n\n\n");

        gui = new AdminGui(new LinuxOsLogic());
        Console.WriteLine("Welcome to cross platfrom app, admin! \n starting on Linux...");
        gui.OpenTextFile();
        Console.WriteLine("starting on Windows...");
        gui = new AdminGui(new WindowsOsLogic());
        gui.OpenTextFile();
    }
}