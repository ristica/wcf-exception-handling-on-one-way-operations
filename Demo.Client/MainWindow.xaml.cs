using System;
using System.ComponentModel;
using System.Windows;
using Demo.Contracts;
using Demo.Proxies;
using System.ServiceModel;

namespace Demo.Client
{
    public partial class MainWindow : Window, IDemoExceptionCallback
    {
        private DemoClient _proxy;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClicked(object sender, RoutedEventArgs e)
        {
            this._proxy = new DemoClient(new InstanceContext(this));
            this._proxy.DoSomething();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this._proxy.Close();
        }

        public void SendError(Exception ex)
        {
            // here you can do everything you want
            // with this exception
            try
            {
                throw ex;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "ArgumentException");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
