using System;
using Xamarin.Forms;

namespace C_Dialogs
{
    public class App
    {
        public static Page GetMainPage()
        {	
            var button1 = new Button
            {
                Text = "Show Alert",
                Font = Font.SystemFontOfSize(30d)
            };

            var button2 = new Button
            {
                Text = "Show ActionSheet",
                Font = Font.SystemFontOfSize(30d)
            };

            var page = new ContentPage
            { 
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children = 
                    {
                        button1,
                        button2
                    }
                }
            };

            button1.Clicked += async (sender, e) => 
            {
                if (await page.DisplayAlert("ご注文は", "ざまりんですか？", "はい", "いいえ")) 
                {
                    button1.Text = "あざす";
                }
            };

            button2.Clicked += async (sender, e) => 
            {
                var selectedText = await page.DisplayActionSheet(
                    "ご注文のざまりんは？", 
                    "買わない", "むしろ売りたい",
                    new string[] { "INDIE", "BUSINESS", "ENTERPRISE" });
                button2.Text = selectedText; // Android で BACK すると null が来る
            };

            return page;
        }
    }
}

