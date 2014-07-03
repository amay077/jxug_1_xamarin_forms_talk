using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace PakaPakaCalc.Views
{
    public partial class AnswerPage
    {
        public Button[] ButtonNumbers { get; private set; }
        public LongClickedButton ButtonClear { get; private set; }
        public Button ButtonEnter { get; private set; }
        public Label LabelAnswer { get; private set; }
        public Label LabelResult { get; private set; }
        public View ViewResult { get; private set; }

        private void InitializeComponent()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                RowSpacing = Style.MarginSmall,
                ColumnSpacing = Style.MarginSmall,
                Padding = new Thickness(Style.MarginMid),
            };

            // Answer label
            this.LabelAnswer = new Label
            {
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                Font = Font.SystemFontOfSize(Style.FontSizeBig),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
            };
            grid.Children.Add(this.LabelAnswer, 0, 3, 0, 1);

            var numberButtons = new List<Button>();

            // 1-9 buttons
            var buttons = Enumerable.Range(1, 9)
                .Select(x => CreateButton(x.ToString()))
                .ToList();

            for (int i = 0; i < buttons.Count; i++)
            {
                grid.Children.Add(buttons[i], i % 3, 1 + (i / 3));
            }

            // 0, clear, enter
            var zeroButton = CreateButton("0");
            grid.Children.Add(zeroButton, 0, 4);

            numberButtons.Add(zeroButton);
            numberButtons.AddRange(buttons);
            this.ButtonNumbers = numberButtons.ToArray();

            this.ButtonClear = CreateLongTapButton("C");
            grid.Children.Add(this.ButtonClear, 1, 4);

            this.ButtonEnter = CreateButton("OK");
            grid.Children.Add(this.ButtonEnter, 2, 4);


            var content = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            content.Children.Add(grid, 
                Constraint.RelativeToParent(p => p.X),
                Constraint.RelativeToParent(p => p.Y),
                Constraint.RelativeToParent(p => p.Width),
                Constraint.RelativeToParent(p => p.Height)
            );

            this.LabelResult = new Label
            {
                Text = "正解！",
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(Style.FontSizeBig),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            this.ViewResult = new StackLayout
            {
                Children =
                {
                    this.LabelResult
                },
                IsVisible = false
            };

            content.Children.Add(
                this.ViewResult, 
                Constraint.RelativeToParent(p => (p.Width - this.ViewResult.Width) / 2d),
                Constraint.RelativeToParent(p => (p.Height - this.ViewResult.Height) / 2d),
                Constraint.RelativeToParent(p => p.Width - (Style.MarginMid * 2)),
                Constraint.Constant(Style.FontSizeBig * 2d));

            this.Content = content;
        }

        private Button CreateButton(string text)
        {
            var btn = new Button 
            {
                Font = Font.SystemFontOfSize(Style.FontSizeLarge),
                Text = text
            };

            return btn;
        }
        private LongClickedButton CreateLongTapButton(string text)
        {
            var btn = new LongClickedButton 
            {
                Font = Font.SystemFontOfSize(Style.FontSizeLarge),
                Text = text
            };

            return btn;
        }
    }
}

