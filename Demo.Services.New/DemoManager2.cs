using System;
using Demo.Contracts;

namespace Demo.Services.New
{
    public class DemoManager2 : IDemoService
    {
        public void DoSomething()
        {
            Console.WriteLine("DemoManager 2 => DoSomething()");
        }
    }
}
