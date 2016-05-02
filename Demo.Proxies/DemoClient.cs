using System.ServiceModel;
using Demo.Contracts;

namespace Demo.Proxies
{
    public class DemoClient : DuplexClientBase<IDemoService>, IDemoService
    {
        public void DoSomething()
        {
            Channel.DoSomething();
        }

        public DemoClient(InstanceContext callbackInstance) 
            : base(callbackInstance)
        {
        }
    }
}
