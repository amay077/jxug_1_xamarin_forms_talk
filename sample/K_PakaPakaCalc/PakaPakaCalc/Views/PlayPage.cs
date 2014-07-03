using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;

namespace PakaPakaCalc.Views
{
    public partial class PlayPage : ContentPage
    {
        public PlayPage(int indexOfQuestion)
        {
            InitializeComponent();

            this.BindingContext = new PlayViewModel(this.Navigation, indexOfQuestion);;

            this.LabelNumber.SetBinding<PlayViewModel>(Label.TextProperty, vm => vm.Number,
                BindingMode.OneWay);

            this.LabelNumber.SetBinding<PlayViewModel>(Label.FontProperty, vm => vm.IsStarting,
                BindingMode.OneWay,
                    new DelegateValueConverter<bool, Font>(x => x ? 
                        Font.SystemFontOfSize(Style.FontSizeBiggest) : 
                        Font.SystemFontOfSize(Style.FontSizeBig), null));
        }
    }
}

