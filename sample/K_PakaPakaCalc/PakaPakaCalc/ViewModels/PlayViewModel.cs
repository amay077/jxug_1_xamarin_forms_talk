using System;
using System.Threading.Tasks;
using PakaPakaCalc.Models;
using Xamarin.Forms;
using PakaPakaCalc.Views;

namespace PakaPakaCalc.ViewModels
{
    public class PlayViewModel : BaseViewModel
    {
        private string _number = String.Empty;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        private bool _isStarting = false;
        public bool IsStarting
        {
            get { return _isStarting; }
            set { SetProperty(ref _isStarting, value); }
        }

        public PlayViewModel(INavigation navigator, int indexOfQuestion) : base(navigator)
        {
            Run(indexOfQuestion);
        }

        private async void Run(int indexOfQuestions)
        {

            this.Number = String.Format("第{0}問 用意…", indexOfQuestions + 1);
            await Task.Delay(1000);
            this.Number = "始め！";
            await Task.Delay(1000);

            this.IsStarting = true;

            var nums = GameModel.Instance.GetNumbers(indexOfQuestions);
            foreach (var item in nums)
            {
                this.Number = item.ToString();
                await Task.Delay((int)(GameModel.Instance.Settings.Intervals * 1000L));
                this.Number = String.Empty;
                await Task.Delay(100);
            }

            this.IsStarting = false;
            this.Number = "おわり";
            await Task.Delay(1000);

            await this.Navigator.PushAsync(new AnswerPage(indexOfQuestions));
        }
    }
}

