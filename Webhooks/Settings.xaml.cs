using System;
using System.Windows;

namespace Webhooks
{
    public partial class Settings : Window
    {
        private readonly XManager webhookManager;

        public Settings()
        {
            InitializeComponent();
            webhookManager = new XManager("settings.xml");
            LoadUrl();
        }

        private void LoadUrl()
        {
            try
            {
                WebhookUrl.Text = webhookManager.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveWebhook(object sender, RoutedEventArgs e)
        {
            try
            {
                webhookManager.Save(WebhookUrl.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
