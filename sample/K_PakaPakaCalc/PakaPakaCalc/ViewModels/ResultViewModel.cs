using System;
using PakaPakaCalc.Models;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PakaPakaCalc.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        private IEnumerable<Stat> _stats;
        public IEnumerable<Stat> Stats
        {
            get { return _stats; }
            set { SetProperty(ref _stats, value); }
        }

        private int _collectCount;
        public int CollectCount
        {
            get { return _collectCount; }
            set { SetProperty(ref _collectCount, value); }
        }

        private int _questionCount;
        public int QuestionCount
        {
            get { return _questionCount; }
            set { SetProperty(ref _questionCount, value); }
        }

        private bool _isPassed;
        public bool IsPassed
        {
            get { return _isPassed; }
            set { SetProperty(ref _isPassed, value); }
        }

        public ResultViewModel(INavigation navigator) : base(navigator)
        {
            var model = GameModel.Instance;
            this.Stats = Enumerable.Range(0, model.Settings.Nums)
                .Select(x => new Stat(x + 1, model.GetCollectAnswer(x), model.GetAnswer(x)))
                .ToList();

            this.CollectCount = this.Stats.Count(x => x.CollectAnswer == x.Answer);
            this.QuestionCount = model.Settings.Nums;
            this.IsPassed = this.CollectCount == model.Settings.Nums;
        }
    }
}

