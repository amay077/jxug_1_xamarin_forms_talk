using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using PakaPakaCalc.iOS;
using MonoTouch.UIKit;
using PakaPakaCalc.Views;

[assembly:ExportRenderer(typeof(LongClickedButton), typeof(LongClickedButtonRenderer))]

namespace PakaPakaCalc.iOS
{
    public class LongClickedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            this.Control.AddGestureRecognizer(new UILongPressGestureRecognizer(x =>
            {
                if (x.State == UIGestureRecognizerState.Recognized) 
                {
                    var btn = e.NewElement as LongClickedButton;
                    if (btn != null) {
                        btn.OnLongClick();
                    }
                }
            }));
        }
    }
}

