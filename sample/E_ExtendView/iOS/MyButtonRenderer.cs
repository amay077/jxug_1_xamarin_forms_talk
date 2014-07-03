using System;
using Xamarin.Forms;
using E_ExtendView;
using E_ExtendView.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;

[assembly:ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]

namespace E_ExtendView.iOS
{
    public class MyButtonRenderer : ButtonRenderer 
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e) 
        {
            base.OnElementChanged(e);

            UIButton iosButton = this.Control; // iOSのButton
            iosButton.AddGestureRecognizer(new UILongPressGestureRecognizer(x => 
            {
                if (x.State == UIGestureRecognizerState.Recognized) 
                {
                    (e.NewElement as MyButton).OnLongTap();
                }
            }));
        }
    }
}

