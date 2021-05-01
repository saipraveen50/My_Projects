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

namespace ChattingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IChattingService Server;
        private static DuplexChannelFactory<IChattingService> duplexChannelFactory;
        public MainWindow()
        {
            InitializeComponent();
            duplexChannelFactory = new DuplexChannelFactory<IChattingService>(new UserCallback(), "ChatServiceEndPoint");
            Server = duplexChannelFactory.CreateChannel();
        }

        public void RecieveMessage(string message, string userName)
        {
            txtsentMessagedisplay.Text += DateTime.Now + "\n" + userName + ":" + message + "\n";
            txtsentMessagedisplay.ScrollToEnd();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Server.SendMessage(txtMessage.Text, txtUserName.Text);
            RecieveMessage(txtMessage.Text, "Me");
            txtMessage.Text = "";
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var loggedIn = Server.Login(txtUserName.Text);

            if (loggedIn == 1)
                MessageBox.Show("User already logged in", "Message", MessageBoxButton.OK,MessageBoxImage.Stop);
            else
            {
                MessageBox.Show("Succesfully logged in", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                lblWelcome.Content = "Welcome" + " " + txtUserName.Text;

                txtUserName.IsEnabled = false;
                btnLogIn.IsEnabled = false;
            }
        }
    }
}
