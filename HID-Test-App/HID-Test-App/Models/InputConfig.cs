namespace HID_Test_App.Models
{
    public enum InputResistor
    {
        PullDown,
        PullUp
    }

    public class InputConfig
    {
        public bool Enabled { get; set; }
        public InputResistor InputResistor { get; set; }

        public InputConfig()
        {
            Enabled = false;
            InputResistor = InputResistor.PullDown;
        }
    }
}
