using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;
using System.Threading.Tasks;

namespace PakaPakaCalc.Views
{
    public partial class AnswerPage : ContentPage
    {
        public AnswerViewModel ViewModel
        {
            get { return this.BindingContext as AnswerViewModel; }
        }

        public AnswerPage(int indexOfQuestions)
        {
            InitializeComponent();
            this.BindingContext = new AnswerViewModel(this.Navigation, indexOfQuestions);;

            this.LabelAnswer.SetBinding<AnswerViewModel>(Label.TextProperty, vm => vm.AnswerText, BindingMode.OneWay, 
                new DelegateValueConverter<string, string>(x => String.IsNullOrEmpty(x) ? "答えは？" : x, null));

            foreach (var btn in this.ButtonNumbers)
            {
                btn.Clicked += (sender, e) => 
                {
                    var b = sender as Button;
                    this.ViewModel.AnswerText = this.ViewModel.AnswerText + b.Text;
                };
            }

            this.ButtonClear.Clicked += (sender, e) => this.ViewModel.AnswerText = String.Empty;
            this.ButtonClear.LongClicked += async (sender, e) => 
            {
                if (await this.DisplayAlert(String.Empty, "はじめにもどりますか？", "はい", "いいえ")) 
                {
                    await this.Navigation.PushAsync(new GameSettingPage());
                }
            };

            this.ViewResult.SetBinding<AnswerViewModel>(View.BackgroundColorProperty, vm => vm.IsCorrectAnswer, BindingMode.OneWay,
                new DelegateValueConverter<bool?, Color>(x => x.HasValue && x.Value ? Color.Blue : Color.Red, null)
            );

            this.ButtonEnter.SetBinding<AnswerViewModel>(Button.CommandProperty, vm => vm.CommandEnterAnswer);
            this.ButtonEnter.SetBinding<AnswerViewModel>(Button.IsEnabledProperty, vm => vm.AnswerText,BindingMode.OneWay, 
                new DelegateValueConverter<string, bool>(x => !String.IsNullOrEmpty(x), null));

            this.ViewModel.PropertyChanged += async (sender, e) => 
            {
                if (String.Equals(e.PropertyName, "IsCorrectAnswer")) {
                    this.LabelResult.Text = this.ViewModel.IsCorrectAnswer.Value ? "正解！" : "不正解";

                    this.ViewResult.IsVisible = true;
                    await Task.Delay(1000);
                    this.ViewResult.IsVisible = false;

                    if (this.ViewModel.CommandNextPage.CanExecute(null)) {
                        this.ViewModel.CommandNextPage.Execute(null);
                    }
                }
            };
        }
    }
}

