using System;
using Xamarin.Forms;
using G_NativeInForms;
using G_NativeInForms.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using System.Drawing;

[assembly:ExportRenderer(typeof(MainPage), typeof(MyPageRenderer))]

namespace G_NativeInForms.iOS
{
    public class MyPageRenderer : PageRenderer 
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e) 
        {
            base.OnElementChanged(e);

            NativeView.Add (new UILabel (new RectangleF(0, 100, 480, 100)) {
                Text = "UILabel from MyPageRenderer",
                TextColor = UIColor.Red,
            });       
        }
    }
}

