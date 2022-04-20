using System.Collections.ObjectModel;

class SmartHouse
{
    private string _smartLampColor;
    private int _fridgeTemperature;
    private string _playingTrackName;
    public string SmartLampColor { get => _smartLampColor; set => _smartLampColor = value; }
    public int FridgeTemperature { get => _fridgeTemperature; set => _fridgeTemperature = value; }
    public string PlayingTrackName { get => _playingTrackName; set => _playingTrackName = value; }
    public SmartHouse(string lampColor, string trackName, int fridgeTemperature)
    {
        _smartLampColor = lampColor;
        _fridgeTemperature = fridgeTemperature;
        _playingTrackName = trackName;
    }
    public void Info()
    {
        Console.WriteLine($"Your smart house system info: \n Playing track - {_playingTrackName} \n" +
            $"Smart lamp color is {_smartLampColor} \nFridge's temperature is {_fridgeTemperature} degrees\n");
    }
}
interface ISmartHouseCommand
{
    void Execute();
    void CancelExecution();
    bool IsExecuted { get; }
}
class ChangeLampColorCommand  : ISmartHouseCommand
{
    private SmartHouse _house;
    private string _previousColor;
    private string _lampColor;
    private bool _isExecuted;
    public bool IsExecuted { get => _isExecuted; }
    public void Execute()
    {
        if (!_isExecuted)
        {
            _house.SmartLampColor = _lampColor;
            _isExecuted = true;
        }
    }

    public void CancelExecution()
    {
        if (_isExecuted)
        {
            _house.SmartLampColor = _previousColor;
            _isExecuted = false;
        }
    }

    public ChangeLampColorCommand(SmartHouse house, string color)
    {
        _isExecuted = false;
        _house = house;
        _previousColor = _house.SmartLampColor;
        _lampColor = color;
    }
}
class ChangeFridgeTempCommand : ISmartHouseCommand
{
    private SmartHouse _house;
    private bool _isExecuted;
    private int _previousTemperature;
    private int _temperature;
    public bool IsExecuted { get => _isExecuted; }
    public void Execute()
    {
        if (!_isExecuted)
        {
            _house.FridgeTemperature = _temperature;
            _isExecuted = true;
        }
    }
    public void CancelExecution()
    {
        if (IsExecuted)
        {
            _house.FridgeTemperature = _previousTemperature;
            _isExecuted = false;
        }
    }
    public ChangeFridgeTempCommand(SmartHouse house, int temp)
    {
        _isExecuted = false;
        _house = house;
        _temperature = temp;
        _previousTemperature = _house.FridgeTemperature;
    }
}
class ChangeTrackCommand : ISmartHouseCommand
{
    private SmartHouse _house;
    private string _trackName;
    private string _previousTrackName;
    private bool _isExecuted;
    public bool IsExecuted { get => _isExecuted; }
    public void Execute()
    {
        if (!_isExecuted)
        {
            _house.PlayingTrackName = _trackName;
            _isExecuted = true;
        }
    }
    public void CancelExecution()
    {
        if (IsExecuted)
        {
            _house.PlayingTrackName = _previousTrackName;
            _isExecuted = false;
        }
    }
    public ChangeTrackCommand(SmartHouse house, string trackName)
    {
        _isExecuted = false;
        _house = house;
        _previousTrackName = _house.PlayingTrackName;
        _trackName = trackName;
    }
}
class Commands : Collection<ISmartHouseCommand>{ }
class SmartHouseScriptExecutor
{
    private string _scriptName;
    public Commands commands;
    private SmartHouse _house;
    public SmartHouseScriptExecutor(SmartHouse house, string scriptName)
    {
        _house = house;
        this._scriptName = scriptName;
        commands = new Commands();
    }
    public void AddCommand(ISmartHouseCommand command)
    {
        commands.Add(command);
    }
    public void ExecuteScript()
    {
        Console.WriteLine($"Executing script: {_scriptName}");
        foreach(var command in commands.ToList<ISmartHouseCommand>())
        {
            command.Execute();
        }
    }
    public void CancelScript()
    {
        Console.WriteLine($"Canceling script: {_scriptName}");
        foreach (var command in commands.ToList<ISmartHouseCommand>())
        {
            command.CancelExecution();
        }
    }
}
class Program
{
    static void Main()
    {
        SmartHouse house = new SmartHouse("Red", "Sweet dreams", 8);
        house.Info();
        // Example of making script for smart house
        SmartHouseScriptExecutor script1 = new SmartHouseScriptExecutor(house, "Beer-drinking script");
        // Did you know that best temperature for beer is 10 celcium degrees? Now you know ╰(*°▽°*)╯
        script1.AddCommand(new ChangeFridgeTempCommand(house, 10));
        script1.AddCommand(new ChangeLampColorCommand(house, "Yellow"));
        script1.AddCommand(new ChangeTrackCommand(house, "various artist - Beer Song!"));
        // Result of script execution and cancelation 
        script1.ExecuteScript();
        house.Info();
        script1.CancelScript();
        house.Info();
    }
}