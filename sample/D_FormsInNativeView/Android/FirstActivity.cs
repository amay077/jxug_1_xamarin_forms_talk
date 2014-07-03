using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;

namespace D_FormsInNativeView.Android
{
    [Activity(Label = "FirstActivity", MainLauncher = true)]
    public class FirstActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.First);

            FindViewById<Button>(Resource.Id.myButton).Click += (sender, e) => 
                StartActivity(typeof(SecondActivity));
        }
    }
}

