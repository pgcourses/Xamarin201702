using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using Day1.ViewModel;
using Day1.Droid;
using Plugin.Permissions;

namespace Day1.Droid
{
    [Activity(Label = "Day1", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CrashManager.Register(this, "02c9889c64e946deb3032cb8101ecb1d");
            CheckForUpdates();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void CheckForUpdates()
        {
            UpdateManager.Register(this, "02c9889c64e946deb3032cb8101ecb1d");
        }

        void UnregisterUpdateManager()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnregisterUpdateManager();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UnregisterUpdateManager();
        }

    }
}

