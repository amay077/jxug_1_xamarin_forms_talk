using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PakaPakaCalc.Views;
using PakaPakaCalc.ViewModels;
using Android.Content.PM;
using Android.Graphics;
using Android.Util;

namespace PakaPakaCalc
{
    [Activity(MainLauncher = true, 
        Theme = "@android:style/Theme.Holo.Light", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Rect rc = new Rect();
            WindowManager.DefaultDisplay.GetRectSize(rc);
            DisplayMetrics m = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(m);

            Style.Init(WindowManager.DefaultDisplay.Width / m.ScaledDensity);
            Xamarin.Forms.Forms.Init(this, bundle);


            var navPage = new NavigationPage(new GameSettingPage());
            SetPage(navPage);
            ActionBar.Hide();
        }

        public override void OnBackPressed()
        {
//            base.OnBackPressed();
        }
    }
}

