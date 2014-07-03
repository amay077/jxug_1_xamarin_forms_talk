using System;
using Xamarin.Forms;

namespace J_MessagingCenter
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            this.BackgroundColor = Color.Silver;
            var button = new Button
            {
                Text = "Send Message",
                Font = Font.SystemFontOfSize(30d),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            button.Clicked += (sender, e) => 
            {
                MessagingCenter.Send(this, "show_toast", "トースト表示");
            };

            this.Content = button;
        }
    }
}

