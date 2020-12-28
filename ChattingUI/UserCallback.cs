using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChattingUI
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserCallback : IClientContracts
    {

    }
}
