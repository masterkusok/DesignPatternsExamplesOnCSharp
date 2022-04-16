class Facade
{
    private SubsystemA _subsystemA;
    private SubsystemB _subsystemB;
    public Facade(SubsystemA subsysA, SubsystemB subsysB)
    {
        _subsystemA = subsysA;
        _subsystemB = subsysB;
    }
    public void SomeOperation()
    {
        Console.WriteLine("First operations of both subsystems");
        _subsystemA.Operation1();
        _subsystemB.Operation1();
        Console.WriteLine("Second operations of both subsystems");
        _subsystemA.Operation2();
        _subsystemB.Operation2();
    }
}
class SubsystemB
{
    public void Operation1()
    {
        Console.WriteLine("Subsystem B, operation 1");
    }
    public void Operation2()
    {
        Console.WriteLine("Subsystem B, operation 2");
    }
}
class SubsystemA
{
    public void Operation1()
    {
        Console.WriteLine("Subsystem A, operation 1");
    }
    public void Operation2()
    {
        Console.WriteLine("Subsystem A, operation 2");
    }
}
class Program
{
    static void Main()
    {
        Facade facade = new Facade(new SubsystemA(), new SubsystemB());
        facade.SomeOperation();
    }
}