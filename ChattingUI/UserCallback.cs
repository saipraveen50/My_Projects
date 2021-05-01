using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChattingUI
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserCallback : IClientContracts
    {
        public void GetMessage(string message, string userName)
        {
            ((MainWindow)Application.Current.MainWindow).RecieveMessage(message, userName);
        }
    }
}
