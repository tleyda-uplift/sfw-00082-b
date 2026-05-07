namespace HID_Test_App.Models
{
    public class InputStatus(int port, int input)
    {
        int Port { get; set; } = port;
        int Input { get; set; } = input;
        bool Enabled { get; set; } = false;
        InputResistor Resistor { get; set; } = InputResistor.PullDown;
        bool State { get; set; } = false;

        override public string ToString()
        {
            return $"Input {Port}.{Input} - {(Resistor == InputResistor.PullUp ? "Pull Up" : "Pull Down")}: {(Enabled ? (State ? "High" : "Low") : "Disabled")}";
        }
    }
}
