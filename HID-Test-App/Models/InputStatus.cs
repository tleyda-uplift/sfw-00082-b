using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HID_Test_App.Models
{
    public class InputStatus : INotifyPropertyChanged
    {
        private bool _enabled;
        private InputResistor _resistor;
        private bool _state;

        int Port { get; }
        int Input { get; }
        public bool Enabled 
        {
            get => _enabled; 
            set
            {
                _enabled = value;
                OnPropertyChanged();
            } 
        }
        public InputResistor Resistor 
        {   
            get => _resistor; 
            set
            {
                _resistor = value;
                OnPropertyChanged();
            }
        }
        public bool State 
        { 
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            } 
        }

        public InputStatus(int port, int input)
        {
            Port = port;
            Input = input;
            _enabled = false;
            _resistor = InputResistor.PullDown;
            _state = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        override public string ToString()
        {
            return Enabled 
                ? $"Input {Port}.{Input} - {(Resistor == InputResistor.PullUp ? "Pull Up" : "Pull Down")}: {(State ? "High" : "Low")}"
                : $"Input {Port}.{Input} - Disabled";
        }
    }
}
