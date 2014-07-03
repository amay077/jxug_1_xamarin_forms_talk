using System;
using Xamarin.Forms;

namespace B_PageTransition
{
    public class App
    {
        public static Page GetMainPage()
        {	
            var btn = new Button
            {
                Text = "Goto Second",
                Font = Font.SystemFontOfSize(30),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var navPage = new NavigationPage(new ContentPage 
            {
                Title = "The First",
                Content = btn
            });

            btn.Clicked += (sender, e) => 
                navPage.PushAsync(App.GetSecondPage());
                
            return navPage;
        }

        static Page GetSecondPage()
        {
            return new ContentPage
            {
                Title = "The Second",
                BackgroundColor = Color.Aqua,
                Content = new Label
                {
                    Text = "This is second",
                    Font = Font.SystemFontOfSize(30),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            };
        }
    }
}

