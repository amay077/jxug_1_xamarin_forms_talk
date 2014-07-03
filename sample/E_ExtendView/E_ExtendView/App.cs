using System;
using Xamarin.Forms;

namespace E_ExtendView
{
    public class App
    {
        public static Page GetMainPage()
        {	
            var button = new MyButton
            {
                Text = "Long tap me",
                Font = Font.SystemFontOfSize(30d)
            };

            button.Clicked += (sender, e) => button.Text = "Clicked";

            button.LongTap += (sender, e) => button.Text = "Long tapped";

            return new ContentPage
            { 
                Content = button
            };
        }
    }
}

