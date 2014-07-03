using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using PakaPakaCalc.Models;
using PakaPakaCalc.Views;

namespace PakaPakaCalc.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        private readonly int _indexOfQuestions;
        public AnswerViewModel(INavigation navigator, int indexOfQuestions) : base(navigator)
        {
            _indexOfQuestions = indexOfQuestions;
        }

        private string _answerText = String.Empty;
        public string AnswerText
        {
            get { return _answerText; }
            set { SetProperty(ref _answerText, value); }
        }

        private bool? _isCorrectAnswer = null;
        public bool? IsCorrectAnswer
        {
            get { return _isCorrectAnswer; }
            set { SetProperty(ref _isCorrectAnswer, value); }
        }

        private ICommand _commandEnterAnswer;
        public ICommand CommandEnterAnswer
        {
            get
            {
                return _commandEnterAnswer ?? (_commandEnterAnswer = 
                    new Command(() => ExecuteCommandEnterAnswer()));
            }
        }

        private void ExecuteCommandEnterAnswer()
        {
            var isCorrect = GameModel.Instance.SetAnswer(_indexOfQuestions, Convert.ToInt32(_answerText));
            this.IsCorrectAnswer = isCorrect;
        }

        private ICommand _commandNextPage;
        public ICommand CommandNextPage
        {
            get
            {
                return _commandNextPage ?? (_commandNextPage = 
                    new Command(() => ExecuteCommandNextPage()));
            }
        }

        private void ExecuteCommandNextPage()
        {
            if (_indexOfQuestions < GameModel.Instance.Settings.Nums - 1)
            {
                this.Navigator.PushAsync(new PlayPage(_indexOfQuestions + 1));
            }
            else
            {
                this.Navigator.PushAsync(new ResultPage());
            }

        }
    }
}

