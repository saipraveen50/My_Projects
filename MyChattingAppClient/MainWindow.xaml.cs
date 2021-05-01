using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyChattingAppClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static IChattingService Server;
        private static DuplexChannelFactory<IChattingService> _channelFactory;
        public MainWindow()
        {
            InitializeComponent();
            _channelFactory = new DuplexChannelFactory<IChattingService>(new ClientCallBack(), "ChattingServiceEndPoint");
            Server = _channelFactory.CreateChannel();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Server.SendMessageToAll(messageTextbox.Text, userNameTextbox.Text);
            TakeMessage(messageTextbox.Text,"Me");
            messageTextbox.Text = "";
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            int returnValue = Server.Login(userNameTextbox.Text);
            if (returnValue == 1)
            {
                MessageBox.Show("Already logged in", "Message", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else if (returnValue == 0)
            {
                MessageBox.Show("Logged in", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                welcomeLabel.Content = "welcome" + " " + userNameTextbox.Text + "!";
                userNameTextbox.IsEnabled = false;
                logInButton.IsEnabled = false;

                LoadUserList(Server.GetCurrentUsers());
            }
        }

        public void TakeMessage(string message ,string userName)
        {
            textBox.Text += DateTime.Now + "\n" + userName + ":" + message + "\n";
            textBox.ScrollToEnd();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Server.Logout();
        }

        public void AddUserToList(string userName)
        {
            if (activeUsersList.Items.Contains(userName))
            {
                return;
            }
            activeUsersList.Items.Add(userName);
        }

        public void RemoveUserfromList(string userName)
        {
            if (activeUsersList.Items.Contains(userName))
            {
                activeUsersList.Items.Remove(userName);
            }
        }

        private void LoadUserList(List<string> users)
        {
            foreach (var user in users)
            {
                AddUserToList(user);
            }
        }
    }
}
