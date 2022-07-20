using System;
using XFLiquors.iOS.Services;
using XFLiquors.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]
namespace XFLiquors.iOS.Services
{
	public class DeviceInfoService:IDeviceInfoService
	{ 

        public string GetDeviceInfo()
        {
            return UIKit.UIDevice.CurrentDevice.Name;
        }
    }
}

