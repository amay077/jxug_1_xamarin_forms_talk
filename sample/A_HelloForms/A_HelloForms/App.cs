using System;
using Xamarin.Forms;

namespace A_HelloForms
{
    public class App
    {
        public static Page GetMainPage()
        {	
            return new ContentPage
            { 
                Content = new DatePicker
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };
        }
    }
}

