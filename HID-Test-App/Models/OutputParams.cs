namespace HID_Test_App.Models
{
    public enum OutputState
    {
        Off,
        On,
        PWM
    }

    public class OutputParams
    {
        public bool ChangeEnabled { get; set; }
        public OutputState State { get; set; }
        public int DutyCycle { get; set; }

        public OutputParams()
        {
            ChangeEnabled = false;
            State = OutputState.Off;
            DutyCycle = 0;
        }
    }
}
