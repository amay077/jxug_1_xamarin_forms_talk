using System;
using Xamarin.Forms;

namespace PakaPakaCalc.ValueConverters
{
    public class DelegateValueConverter<T, U> : IValueConverter 
    {
        private readonly Func<T, U> _conv;
        private readonly Func<U, T> _inverse;

        public DelegateValueConverter(Func<T, U> conv, Func<U, T> inv)
        {
            _conv = conv;
            _inverse = inv;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return _conv((T)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return _inverse((U)value);
        }
    }
}

