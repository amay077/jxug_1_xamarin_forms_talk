using System;
using Xamarin.Forms;

namespace D_FormsInNativeView
{
    public class MainPage : ContentPage
    {
        public Button GotoThirdButton  {
            get;
            private set;
        }

        public MainPage()
        {
            this.Title = "Page by Xamarin.Forms";
            this.BackgroundColor = Color.Aqua;

            this.GotoThirdButton = new Button
            {
                Text = "Goto Third",
                Font = Font.SystemFontOfSize(30),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            this.Content = this.GotoThirdButton;
        }
    }
}

