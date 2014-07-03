using System;
using Xamarin.Forms;

namespace E_ExtendView
{
    public class MyButton : Button
    {
        public event EventHandler LongTap;

        public void OnLongTap()
        {
            if (this.LongTap != null)
            {
                this.LongTap(this, new EventArgs());
            }
        }
    }
}

