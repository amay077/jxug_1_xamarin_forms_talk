using System;
using Xamarin.Forms;
using System.Collections.Generic;
using PakaPakaCalc.ValueConverters;
using PakaPakaCalc.ViewModels;

namespace PakaPakaCalc.Views
{
    public partial class GameSettingPage : ContentPage
    {
        public GameSettingPage()
        {
            InitializeComponent();

            this.BindingContext = new GameSettingViewModel(this.Navigation);;

            this.LabelNums.SetBinding<GameSettingViewModel>(Label.TextProperty, vm => vm.QuestionNum, 
                BindingMode.OneWay, null, "問題数:{0}");

            this.SliderNums.SetBinding<GameSettingViewModel>(Slider.ValueProperty, vm => vm.QuestionNum,
                BindingMode.TwoWay, new DelegateValueConverter<int, double>(Convert.ToDouble, Convert.ToInt32));

            this.LabelTimes.SetBinding<GameSettingViewModel>(Label.TextProperty, vm => vm.QuestionTimes,
                BindingMode.OneWay, null, "口数:{0}");

            this.SliderTimes.SetBinding<GameSettingViewModel>(Slider.ValueProperty, vm => vm.QuestionTimes,
                BindingMode.TwoWay, new DelegateValueConverter<int, double>(Convert.ToDouble, Convert.ToInt32));

            this.LabelDigits.SetBinding<GameSettingViewModel>(Label.TextProperty, vm => vm.QuestionDigits,
                BindingMode.OneWay, null, "桁数:{0}");

            this.SliderDigits.SetBinding<GameSettingViewModel>(Slider.ValueProperty, vm => vm.QuestionDigits,
                BindingMode.TwoWay, new DelegateValueConverter<int, double>(Convert.ToDouble, Convert.ToInt32));

            this.LabelIntervals.SetBinding<GameSettingViewModel>(Label.TextProperty, vm => vm.Intervals,
                BindingMode.OneWay, null, "間隔:{0:0.0}秒");

            this.SliderIntervals.SetBinding<GameSettingViewModel>(Slider.ValueProperty, vm => vm.Intervals,
                BindingMode.TwoWay);

            this.ButtonPlay.SetBinding<GameSettingViewModel>(Button.CommandProperty, vm => vm.CommandPlay);
        }
    }
}

