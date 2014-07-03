
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace D_FormsInNativeView.Android
{
    [Activity(Label = "SecondActivity")]			
    public class SecondActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            var page = new MainPage();

            page.GotoThirdButton.Clicked += (sender, e) => 
                StartActivity(typeof(ThirdActivity));

            SetPage(new NavigationPage(page));
        }
    }
}

