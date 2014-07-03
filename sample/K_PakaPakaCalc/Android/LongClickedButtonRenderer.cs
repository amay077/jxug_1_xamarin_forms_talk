using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PakaPakaCalc.Android;
using PakaPakaCalc.Views;

[assembly:ExportRenderer(typeof(LongClickedButton), typeof(LongClickedButtonRenderer))]

namespace PakaPakaCalc.Android
{
    public class LongClickedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            this.Control.LongClick += (sender, args) => 
            {
                var btn = e.NewElement as LongClickedButton;
                if (btn == null) 
                {
                    return;
                }
                btn.OnLongClick();
            };
        }
    }
}

