using System;
using System.ComponentModel;
using System.Windows.Input;

namespace I_DataBinding
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _myName;
        public string MyName 
        {
            get { return _myName; }
            set 
            { 
                if (_myName == value)
                {
                    return;
                }

                _myName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyName"));
            }
        }

        ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = 
                    new Xamarin.Forms.Command(() =>
                {
                    MyName = "xamariiiiin!!";
                }));
            }
        }

    }
}

