using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;
using PakaPakaCalc.Models;

namespace PakaPakaCalc.Views
{
    public partial class ResultPage : ContentPage
    {
        public ResultViewModel ViewModel
        {
            get { return this.BindingContext as ResultViewModel; }
        }

        public ResultPage()
        {
            InitializeComponents();

            this.BindingContext = new ResultViewModel(this.Navigation);

            this.ButtonNextGame.Clicked += (sender, e) => Navigation.PushAsync(new GameSettingPage());

            this.LabelResult.SetBinding<ResultViewModel>(Label.TextProperty, vm => vm.IsPassed, BindingMode.OneWay, 
                new DelegateValueConverter<bool, string>(x => x ? "合格！" : "不合格…", null));

            this.LabelStats.SetBinding<ResultViewModel>(Label.TextProperty, vm => vm.CollectCount, BindingMode.OneWay, 
                new DelegateValueConverter<int, string>(x => String.Format("{0}問中、{1}問正解", this.ViewModel.QuestionCount, x), null));

            this.ListViewResult.ItemsSource = this.ViewModel.Stats;
            this.ListViewResult.ItemTemplate = new DataTemplate(() =>
            {

                Func<Binding> colorBinding = () => Binding.Create<Stat>(vm => vm.IsCollect, BindingMode.OneWay, 
                    new DelegateValueConverter<bool, Color>(x => x ? Color.Black : Color.Red, null));

                var labelNumber = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeMid),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };
                labelNumber.SetBinding<Stat>(Label.TextProperty, vm => vm.Number,
                    BindingMode.OneWay, null, "{0}.");
                labelNumber.SetBinding(Label.TextColorProperty, colorBinding());

                var labelIsCollect = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeLarge),
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };
                labelIsCollect.SetBinding<Stat>(Label.TextProperty, vm => vm.IsCollect, BindingMode.OneWay, 
                    new DelegateValueConverter<bool, string>(x => x ? "○" : "×", null));
                labelIsCollect.SetBinding(Label.TextColorProperty, colorBinding());

                var labelAnswer = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeMid),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                labelAnswer.SetBinding<Stat>(Label.TextProperty, vm => vm.Answer,
                    BindingMode.OneWay, null, "回答:{0}");
                labelAnswer.SetBinding(Label.TextColorProperty, colorBinding());

                var labelCollectAnswer = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeMid),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                labelCollectAnswer.SetBinding<Stat>(Label.TextProperty, vm => vm.CollectAnswer,
                    BindingMode.OneWay, null, "正解:{0}");
                labelCollectAnswer.SetBinding(Label.TextColorProperty, colorBinding());

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            labelNumber,
                            labelIsCollect,
                            labelAnswer,
                            labelCollectAnswer,
                        },
                        VerticalOptions = LayoutOptions.Center,
                    }
                };
            });

        }
    }
}

