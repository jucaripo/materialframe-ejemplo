using System;
using System.Collections.Generic;
using materialFrame.ViewModels;
using materialFrame.Views;
using Xamarin.Forms;

namespace materialFrame
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
