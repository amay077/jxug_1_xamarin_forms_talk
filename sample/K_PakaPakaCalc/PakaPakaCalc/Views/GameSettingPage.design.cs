using System;
using Xamarin.Forms;

namespace PakaPakaCalc.Views
{
    public partial class GameSettingPage
    {
        public Label LabelNums { get; private set; }
        public Slider SliderNums { get; private set; }
        public Label LabelTimes { get; private set; }
        public Slider SliderTimes { get; private set; }
        public Label LabelDigits { get; private set; }
        public Slider SliderDigits { get; private set; }
        public Label LabelIntervals { get; private set; }
        public Slider SliderIntervals { get; private set; }
        public Button ButtonPlay { get; private set; }

        private void InitializeComponent()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            Func<Label> lableTitle = () => new Label { Font = Font.SystemFontOfSize(Style.FontSizeMid) };

            var pageTitle = new Label
            {
                Text = "ゲームの設定",
                Font = Font.SystemFontOfSize(Style.FontSizeMid),
                XAlign = TextAlignment.Center,
            };

            Func<View> spacer = () => new BoxView
            {
                HeightRequest = Style.MarginSmall
            };

            // 問題数
            this.LabelNums = lableTitle();
            this.SliderNums = new Slider
            {
                Maximum = 15d,
                Minimum = 1d,
            };

            // 口数
            this.LabelTimes = lableTitle();
            this.SliderTimes = new Slider
            {
                Maximum = 15d,
                Minimum = 3d,
            };

            // 桁数
            this.LabelDigits = lableTitle();
            this.SliderDigits = new Slider
            {
                Maximum = 5d,
                Minimum = 1d,
            };

            // 桁数
            this.LabelIntervals = lableTitle();
            this.SliderIntervals = new Slider
            {
                Maximum = 3d,
                Minimum = 0.5d,
            };

            // 開始ボタン
            this.ButtonPlay = new Button
            {
                Text = "はじめる",
                Font = Font.SystemFontOfSize(Style.FontSizeLarge),
                VerticalOptions = LayoutOptions.End,
            };

            var contents = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                        this.LabelTimes,
                        this.SliderTimes,
                        spacer(),
                        this.LabelDigits,
                        this.SliderDigits,
                        spacer(),
                        this.LabelIntervals,
                        this.SliderIntervals,
                        spacer(),
                        this.LabelNums,
                        this.SliderNums,
                    },
                    VerticalOptions = LayoutOptions.Start,
                }
            };


            this.Content = new StackLayout
            { 
                Padding = new Thickness(Style.MarginMid),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    pageTitle,
                    spacer(),
                    contents,
                    spacer(),
                    this.ButtonPlay,
                }
            };
        }
    }
}

