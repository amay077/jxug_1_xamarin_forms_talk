using System;
using Xamarin.Forms;


namespace PakaPakaCalc.Views
{
    public partial class PlayPage
    {
//        public Label LabelTitle { get; private set; }
        public Label LabelNumber { get; private set; }
        public Button ButtonCancel { get; private set; }

        private void InitializeComponent()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            this.LabelNumber = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            this.ButtonCancel = new Button
            {
                Text = "×",
                Font = Font.SystemFontOfSize(Style.FontSizeMid),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End,
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    this.LabelNumber,
                },
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
        }
    }
}

