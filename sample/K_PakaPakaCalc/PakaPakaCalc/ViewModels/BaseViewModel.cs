using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace PakaPakaCalc.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        internal BaseViewModel(INavigation navigator)
        {
            this.Navigator = navigator;
        }

        protected INavigation Navigator { get; private set; }

        protected void SetProperty<U>(
            ref U backingStore, U value,
            [CallerMemberName] string propertyName = null,
            Action onChanged = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            if (onChanged != null)
                {
                    onChanged();
                }

            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

