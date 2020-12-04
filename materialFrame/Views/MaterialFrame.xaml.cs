using System;
using System.ComponentModel;
using System.Threading.Tasks;

using Sharpnado.Tasks;

using Xamarin.Forms;


namespace materialFrame.Views
{
    public partial class MaterialFrame : ContentPage
    {
        private bool _isAcrylicBlurEnabled;

        private Sharpnado.MaterialFrame.MaterialFrame.BlurStyle _blurStyle;
     

        private bool _isSettingsShown;

        private static readonly GridLength SettingsRowHeight = new GridLength(40);

        private readonly Button[] _blurStyleButtons;

        public MaterialFrame()
        {
            InitializeComponent();

            

            _blurStyleButtons = new[] { LightButton, DarkButton, ExtraLightButton };

            SettingsFrame.IsVisible = _isSettingsShown;
            SettingsFrame.Opacity = _isSettingsShown ? 1 : 0;

             BlurSwitch.IsToggled = false;
             SwitchOnToggled(BlurSwitch, new ToggledEventArgs(false));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            TaskMonitor.Create(DelayExecute);
        }

        private async Task DelayExecute()
        {
            await Task.Delay(3000);

        }


        private void SettingsButtonOnClicked(object sender, EventArgs e)
        {
            if (!_isSettingsShown)
            {
                BlurStyleRow.Height = _isAcrylicBlurEnabled ? SettingsRowHeight : 0;
                SettingsFrame.IsVisible = true;

                TaskMonitor.Create(SettingsFrame.FadeTo(1));
                _isSettingsShown = true;
                return;
            }

            // Hide
            _isSettingsShown = false;
            TaskMonitor.Create(async () =>
            {
                await SettingsFrame.FadeTo(0);
                SettingsFrame.IsVisible = false;
            });
        }

        private void SwitchOnToggled(object sender, ToggledEventArgs e)
        {
            var switchBlur = (Switch)sender;

            _isAcrylicBlurEnabled = switchBlur.IsToggled;

            if (_isAcrylicBlurEnabled)
            {
                ResourcesHelper.SetAcrylic(true);
                BlurStyleButtonOnClicked(LightButton, EventArgs.Empty);
            }
            else
            {
                ResourcesHelper.SetAcrylic(false);
            }

            BlurStyleRow.Height = _isAcrylicBlurEnabled ? SettingsRowHeight : 0;
            foreach (var button in _blurStyleButtons)
            {
                button.IsVisible = _isAcrylicBlurEnabled;
            }
        }

        private void BlurStyleButtonOnClicked(object sender, EventArgs e)
        {
            var selectedButton = (Button)sender;

            if (selectedButton == LightButton)
            {
                _blurStyle = Sharpnado.MaterialFrame.MaterialFrame.BlurStyle.Light;

            }
            else if (selectedButton == DarkButton)
            {
                _blurStyle = Sharpnado.MaterialFrame.MaterialFrame.BlurStyle.Dark;
            }
            else
            {
                _blurStyle = Sharpnado.MaterialFrame.MaterialFrame.BlurStyle.ExtraLight;
            }

            ResourcesHelper.SetBlurStyle(_blurStyle);

            selectedButton.TextColor = _blurStyle != Sharpnado.MaterialFrame.MaterialFrame.BlurStyle.ExtraLight
                                           ? ResourcesHelper.GetResourceColor("TextPrimaryColor")
                                           : ResourcesHelper.GetResourceColor("TextPrimaryDarkColor");

            selectedButton.BackgroundColor = ResourcesHelper.GetResourceColor(ResourcesHelper.DynamicPrimaryColor);

            foreach (var button in _blurStyleButtons)
            {
                if (button == selectedButton)
                {
                    continue;
                }

                button.TextColor = _blurStyle != Sharpnado.MaterialFrame.MaterialFrame.BlurStyle.ExtraLight
                                       ? ResourcesHelper.GetResourceColor("TextPrimaryDarkColor")
                                       : ResourcesHelper.GetResourceColor("TextPrimaryColor");
                button.BackgroundColor = Color.Transparent;
            }
        }

    }
}
