using System;
using Xamarin.Forms;

namespace F_MyMapView
{
    public class App
    {
        public static Page GetMainPage()
        {	
            return new ContentPage
            { 
                Content = new MyMapView
                {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                },
            };
        }
    }
}

