using System;
using Xamarin.Forms;

namespace PakaPakaCalc.Views
{
    public partial class ResultPage
    {
        public Label LabelResult { get; private set; }
        public Label LabelStats { get; private set; }
        public Button ButtonNextGame { get; private set; }
        public Button ButtonEndGame { get; private set; }
        public ListView ListViewResult { get; private set; }

        public void InitializeComponents()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            Func<View> spacer = () => new BoxView
            {
                HeightRequest = Style.MarginSmall
            };

            var header = new Label
            {
                Text = "結果",
                Font = Font.SystemFontOfSize(Style.FontSizeMid),
                XAlign = TextAlignment.Center,
            };

            this.LabelResult = new Label
            {
                Font = Font.SystemFontOfSize(Style.FontSizeBig),
                XAlign = TextAlignment.Center,
            };

            this.LabelStats = new Label
            {
                Text = "○○問中○○問正解",
                Font = Font.SystemFontOfSize(Style.FontSizeMid),
                XAlign = TextAlignment.Center,
            };

            this.ListViewResult = new ListView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowHeight = (int)Style.FontSizeMid * 2,
            };

            var content = new StackLayout
            {
                Children = 
                {
                    this.LabelResult,
                    spacer(),
                    this.LabelStats,
                    this.ListViewResult,
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            this.ButtonNextGame = new Button
            {
                Text = "もう一度",
                Font = Font.SystemFontOfSize(Style.FontSizeLarge),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            var footer = new StackLayout
            {
                Children = 
                {
                    this.ButtonNextGame,
                },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
            };

            this.Content = new StackLayout
            {
                Padding = new Thickness(Style.MarginMid),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    header,
                    spacer(),
                    content,
                    footer,
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

        }
    }
}

