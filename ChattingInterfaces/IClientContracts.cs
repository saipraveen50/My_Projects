﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChattingInterfaces
{
    public interface IClientContracts
    {
        [OperationContract]
        void GetMessage(string message, string userName);
    }
}
