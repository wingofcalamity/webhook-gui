using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Webhooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpController httpController;
        public MainWindow()
        {
            httpController = new HttpController();
            InitializeComponent();
        }

        private void openSettings(object sender, RoutedEventArgs e)
        {
            Settings settingsWindow = new Settings();
            settingsWindow.Owner = this;
            settingsWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            settingsWindow.Left = Left + (Width - settingsWindow.Width) / 2;
            settingsWindow.Top = Top + (Height - settingsWindow.Height) / 2;
            settingsWindow.Show();
        }
        private async void sendMessage(object sender, RoutedEventArgs e)
        {
            string message = Message.Text;
            await httpController.sendAsync(message);
        }
    }
}