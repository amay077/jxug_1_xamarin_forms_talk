using System;
using Xamarin.Forms;

namespace I_DataBinding
{
    public class MyPage : ContentPage
    {
        public MyPage()
        {
            var editBox = new Entry 
            {
            };

            var label = new Label 
            {
                Font = Font.SystemFontOfSize(30d)
            };

            var button = new Button 
            { 
                Text = "Reset",
                Font = Font.SystemFontOfSize(30d)
            };

            this.BindingContext = new MyViewModel();
            editBox.SetBinding(Entry.TextProperty, "MyName");
            label.SetBinding(Label.TextProperty, "MyName");
            button.SetBinding(Button.CommandProperty, "ResetCommand");

            this.Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Orientation = StackOrientation.Vertical,
                Spacing = 5,
                Children = 
                {
                    editBox,
                    label,
                    button
                }
            };
        }
    }
}

