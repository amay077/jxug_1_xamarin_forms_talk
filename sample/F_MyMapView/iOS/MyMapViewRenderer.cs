using System;
using Xamarin.Forms;
using F_MyMapView;
using F_MyMapView.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.MapKit;

[assembly:ExportRenderer(typeof(MyMapView), typeof(MyMapViewRenderer))]

namespace F_MyMapView.iOS
{
    public class MyMapViewRenderer : ViewRenderer<MyMapView, MKMapView> 
    {
        protected override void OnElementChanged (ElementChangedEventArgs<MyMapView> e) 
        {
            base.OnElementChanged(e);

            // 独自のコントロールに置き換えちゃう
            SetNativeControl(new MonoTouch.MapKit.MKMapView());
        }
    }
}

