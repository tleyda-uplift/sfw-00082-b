using HID_Test_App.Commands;
using HID_Test_App.Services;
using HID_Test_App.Views;

namespace HID_Test_App.Presenters
{
    public class MainPresenter
    {
        private readonly IMainForm mainForm;
        private IHidService hidService;
        private readonly OutputCommandBuilder outputCommandBuilder;

        public MainPresenter(IMainForm mainForm, IHidService hidService)
        {
            this.mainForm = mainForm;
            this.hidService = hidService;

            this.mainForm.VendorId = "2047";
            this.mainForm.ProductId = "3737";
            this.mainForm.ConnectEnabled = true;
            this.mainForm.DisconnectEnabled = false;

            this.mainForm.ConnectClicked += MainForm_ConnectClicked;
            this.mainForm.DisconnectClicked += MainForm_DisconnectClicked;

            outputCommandBuilder = new OutputCommandBuilder();
        }

        private void MainForm_DisconnectClicked(object? sender, EventArgs e)
        {
            hidService.Disconnect();
            mainForm.ConnectEnabled = true;
            mainForm.DisconnectEnabled = false;
        }

        private void MainForm_ConnectClicked(object? sender, EventArgs e)
        {
            Console.WriteLine("Connect Clicked");

            var vendorId = Convert.ToInt32(mainForm.VendorId, 16);
            var productId = Convert.ToInt32(mainForm.ProductId, 16);

            bool connected = hidService.Connect(vendorId, productId);

            if (connected) 
            {
                mainForm.ConnectEnabled = false;
                mainForm.DisconnectEnabled = true;
            }
        }
    }
}
