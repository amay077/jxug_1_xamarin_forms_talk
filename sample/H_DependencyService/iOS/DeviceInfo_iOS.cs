using System;
using H_DependencyService.iOS;
using Xamarin.Forms;
using MonoTouch.UIKit;

[assembly: Dependency (typeof (DeviceInfo_iOS))] // これ重要！

namespace H_DependencyService.iOS
{
    public class DeviceInfo_iOS : IDeviceInfo
    {
        public string DeviceName 
        {
            get 
            { 
                return UIDevice.CurrentDevice.Name; 
            }
        }
    }
}

