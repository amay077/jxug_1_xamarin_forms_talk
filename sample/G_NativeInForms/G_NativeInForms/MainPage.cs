using System;
using Xamarin.Forms;

namespace G_NativeInForms
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            this.Content = new Label
            {
                Text = "Label from Forms",
                Font = Font.SystemFontOfSize(30d),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}

