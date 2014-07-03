using System;
using H_DependencyService.Android;
using Xamarin.Forms;

[assembly: Dependency (typeof (DeviceInfo_Android))]

namespace H_DependencyService.Android
{
    public class DeviceInfo_Android : IDeviceInfo
    {
        public string DeviceName 
        {
            get 
            { 
                return global::Android.OS.Build.Device; 
            }
        }
    }
}

