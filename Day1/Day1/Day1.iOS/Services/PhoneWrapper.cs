using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Day1.iOS.Services;
using Day1.Services;

[assembly: Dependency(typeof(PhoneWrapper))]
namespace Day1.iOS.Services
{
    public class PhoneWrapper : IPhoneWrapper
    {
        public bool PhoneCall(string phoneNumber)
        {
            return UIApplication.SharedApplication.OpenUrl(new NSUrl($"tel:{phoneNumber}"));
        }
    }
}