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
using Day1.Services;
using Xamarin.Forms;
using Day1.Droid.Services;
using Android.Telephony;

[assembly: Dependency(typeof(PhoneWrapper))]
namespace Day1.Droid.Services
{
    public class PhoneWrapper : IPhoneWrapper
    {
        public bool PhoneCall(string phoneNumber)
        {
            var ctx = Forms.Context;
            if (ctx == null) { return false; }

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse($"tel: {phoneNumber}"));

            if (!IsIntentAvailable(ctx, intent)) { return false; }

            ctx.StartActivity(intent);
            return true;
        }

        private bool IsIntentAvailable(Context ctx, Intent intent)
        {
            var pm = ctx.PackageManager;
            var list = pm.QueryIntentServices(intent, 0)
                         .Union(pm.QueryIntentActivities(intent, 0));

            if (list.Any()) { return true; }

            var mgr = TelephonyManager.FromContext(ctx);
            return mgr.PhoneType != PhoneType.None;
        }
    }
}