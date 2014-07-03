using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using Xamarin.Forms;

namespace D_FormsInNativeView.iOS
{
	partial class SecondViewController : UIViewController
	{
		public SecondViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Forms.Init(); // 初期化
            // Page→ViewController
            var page = new MainPage();
            var vc = page.CreateViewController();
            // Page 側のボタンのイベントハンドラ(画面遷移)
            page.GotoThirdButton.Clicked += (sender, e) => 
                this.PerformSegue("goto_third", this);
            // Pageを親ViewControllerに追加
            this.AddChildViewController(vc);
            this.View.Add(vc.View);
            vc.DidMoveToParentViewController(this);
        }
	}
}
