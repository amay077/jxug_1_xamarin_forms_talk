using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using PakaPakaCalc.Views;
using PakaPakaCalc.ViewModels;

namespace PakaPakaCalc
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);
			
            Style.Init(UIScreen.MainScreen.Bounds.Size.Width);
            window.RootViewController = new NavigationPage(new GameSettingPage()).CreateViewController();
            window.MakeKeyAndVisible();
			
            return true;
        }
    }
}

