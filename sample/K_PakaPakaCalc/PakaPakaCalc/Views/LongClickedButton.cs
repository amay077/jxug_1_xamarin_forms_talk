using System;
using Xamarin.Forms;

namespace PakaPakaCalc.Views
{
    public class LongClickedButton : Button
    {
        public event EventHandler LongClicked;

        public void OnLongClick()
        {
            if (this.LongClicked != null)
            {
                this.LongClicked(this, new EventArgs());
            }
        }
    }
}

