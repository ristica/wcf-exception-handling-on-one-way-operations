using System;
using System.ServiceModel;

namespace Demo.Contracts
{
    [ServiceContract(CallbackContract = typeof(IDemoExceptionCallback))]
    public interface IDemoService
    {
        [OperationContract(IsOneWay = true)]
        void DoSomething();
    }

    [ServiceContract]
    public interface IDemoExceptionCallback
    {
        [OperationContract]
        // very important:
        // we need to seralize each type that has to be 
        // handled by the service
        // just like we would do it for FaultException<T>
        [ServiceKnownType(typeof(ArgumentException))]
        void SendError(Exception ex);
    }
}
