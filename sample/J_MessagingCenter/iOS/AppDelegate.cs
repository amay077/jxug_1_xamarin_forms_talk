using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using BigTed;

namespace J_MessagingCenter.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            MessagingCenter.Subscribe<MainPage, string>(this, "show_toast", 
                (sender, param) =>
            {
                BTProgressHUD.ShowToast(param, false, 3000d);
            });

            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);
			
            window.RootViewController = new MainPage().CreateViewController();
            window.MakeKeyAndVisible();
			
            return true;
        }
    }
}

