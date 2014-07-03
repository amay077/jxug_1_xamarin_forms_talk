using System;
using Xamarin.Forms;

namespace H_DependencyService
{
    public class App
    {
        public static Page GetMainPage()
        {	
            var info = DependencyService.Get<IDeviceInfo>();

            var deviceName = String.Empty;
            if (info != null)
            {
                deviceName = info.DeviceName;
            }

            return new ContentPage
            { 
                Content = new Label
                {
                    Text = deviceName,
                    Font = Font.SystemFontOfSize(30d),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };
        }
    }
}

