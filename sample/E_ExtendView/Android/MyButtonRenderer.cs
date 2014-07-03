using System;
using Xamarin.Forms.Platform.Android;
using E_ExtendView;
using E_ExtendView.Android;
using Xamarin.Forms;

[assembly:ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]

namespace E_ExtendView.Android
{
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e) 
        {
            base.OnElementChanged(e);

            var formsButton = e.NewElement as MyButton; // FormsのButton
            var droidButton = this.Control; // AndroidのButton

            droidButton.LongClick += (sender, _) => 
                formsButton.OnLongTap();
        }
    }
}

