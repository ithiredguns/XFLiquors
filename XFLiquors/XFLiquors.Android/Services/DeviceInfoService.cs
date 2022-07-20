using System;
using XFLiquors.Droid.Services;
using XFLiquors.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]
namespace XFLiquors.Droid.Services
{
	public class DeviceInfoService:IDeviceInfoService
	{ 
        public string GetDeviceInfo()
        {
            return Android.OS.Build.Device;
        }
    }
}

