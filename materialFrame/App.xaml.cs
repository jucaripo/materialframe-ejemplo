using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using materialFrame.Services;
using materialFrame.Views;

namespace materialFrame
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Sharpnado.MaterialFrame.Initializer.Initialize(loggerEnable: false, debugLogEnable: false);

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
