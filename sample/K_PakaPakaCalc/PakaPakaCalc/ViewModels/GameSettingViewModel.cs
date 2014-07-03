using System;
using System.ComponentModel;
using System.Collections.Generic;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.Models;
using Xamarin.Forms;
using PakaPakaCalc.Views;

namespace PakaPakaCalc.ViewModels
{
    public class GameSettingViewModel : BaseViewModel
    {
        public GameSettingViewModel(INavigation navigator) : base(navigator)
        {
            LoadSetting();
        }

        private async void LoadSetting()
        {
            var settings = await GameModel.Instance.LoadSettings();
            if (settings != null)
            {
                this.QuestionNum = settings.Nums;
                this.Intervals = settings.Intervals;
                this.QuestionDigits = settings.Digits;
                this.QuestionTimes = settings.Times;
            }
        }

        private int _questionNum = 5;
        public int QuestionNum
        {
            get { return _questionNum; }
            set { SetProperty(ref _questionNum, value); }
        }

        private int _questionTimes = 5;
        public int QuestionTimes
        {
            get { return _questionTimes; }
            set { SetProperty(ref _questionTimes, value); }
        }

        private double _intervals = 1d;
        public double Intervals
        {
            get { return _intervals; }
            set { SetProperty(ref _intervals, value); }
        }

        private int _questionDigits = 1;
        public int QuestionDigits
        {
            get { return _questionDigits; }
            set { SetProperty(ref _questionDigits, value); }
        }

        private Command _commandPlay;
        public Command CommandPlay
        {
            get
            {
                return _commandPlay ?? (_commandPlay = new Command(async _ => 
                {
                    var settings = new GameSettings(this.QuestionDigits, this.QuestionTimes, this.Intervals, this.QuestionNum);
                    await GameModel.Instance.BuildGame(settings);

                    await this.Navigator.PushAsync(new PlayPage(0));
                }));
            }
        }


    }
}

