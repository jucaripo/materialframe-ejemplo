using System.ComponentModel;
using Xamarin.Forms;
using materialFrame.ViewModels;

namespace materialFrame.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}