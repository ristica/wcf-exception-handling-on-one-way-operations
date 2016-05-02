using System;
using System.ServiceModel;
using Demo.Contracts;

namespace Demo.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class DemoManager : IDemoService
    {
        public void DoSomething()
        {
            try
            {
                Console.WriteLine("DoSomething() => invoked!");

                //// this will throw exception but will never make to client
                //var ex = new ArgumentException("this is a test argument exception");
                //throw new FaultException<ArgumentException>(ex, ex.Message);

                var ex = new ArgumentException("this is a test argument exception");
                throw ex;
            }
            catch (Exception ex)
            {
                var callback = OperationContext.Current.GetCallbackChannel<IDemoExceptionCallback>();

                // if you get an error like:
                // error on deserializing of the parameter 'ex'...
                // then you forgot to set 
                // [ServiceKnownType(typeof(ArgumentException))]
                // on your contract
                callback?.SendError(ex);
            }
        }
    }
}
