using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;


namespace J_MessagingCenter.Android
{
    [Activity(Label = "J_MessagingCenter.Android.Android", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MessagingCenter.Subscribe<MainPage, string>(this, "show_toast", 
            (sender, param) =>
            {
                Toast.MakeText(this, param, ToastLength.Long).Show();
            });

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(new MainPage());
        }
    }
}

