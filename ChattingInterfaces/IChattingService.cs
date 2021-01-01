using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChattingInterfaces
{
    /// <summary>
    /// interface for performing chat operation
    /// </summary>
    [ServiceContract(CallbackContract =typeof(IClientContracts))]
    public interface IChattingService
    {
        [OperationContract]
        int Login(string userName);
        [OperationContract]
        void Logout();
    }
}
