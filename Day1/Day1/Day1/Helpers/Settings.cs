// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Day1.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Ezen a property-n keresztül érjük el a plugin-t.
        /// Ehhez kapunk egy Singleton példányt, vagyis, az egész
        /// alkalmazáson belül akárhányszor kérjük el, mindig ugyanazt 
        /// kapjuk
        /// 
        /// A Settings környezet egy szótárba (Dictionary) menti el az információkat
        /// ehhez minden platformon saját implementációt használ.
        /// 
        /// szótár: kulcs/érték pároknak a gyüjteménye, kulcs alapján tudunk benne keresni/módosítani
        /// 
        /// Ezeket a típusokat tudjuk menteni
        /// 
        /// Boolean
        /// Int32
        /// Int64
        /// String
        /// Single(float)
        /// Guid
        /// Double
        /// Decimal
        /// DateTime(Will always be stored and retrieved in UTC)
        /// 
        /// Részletesen: https://github.com/jamesmontemagno/SettingsPlugin
        /// 
        /// </summary>
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        #region Setting Constants

        //Ez lesz a szótárban a kulcs
        private const string NickNameSettingsKey = "NickName_key";
        //ez meg az alapértelmezett érték
        private static readonly string NickNameSettingsDefault = string.Empty;

        private const string NetworkOnlyIfWifiSettingsKey = "NetworkOnlyIfWifi_key";
        //ez meg az alapértelmezett érték
        private static readonly bool NetworkOnlyIfWifiSettingsDefault = true;

        #endregion


        public static string NickName
        {
            get { return AppSettings.GetValueOrDefault<string>(NickNameSettingsKey, NickNameSettingsDefault); }
            set { AppSettings.AddOrUpdateValue<string>(NickNameSettingsKey, value); }
        }

        public static bool NetworkOnlyIfWifi
        {
            get { return AppSettings.GetValueOrDefault<bool>(NetworkOnlyIfWifiSettingsKey, NetworkOnlyIfWifiSettingsDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(NetworkOnlyIfWifiSettingsKey, value); }
        }
    }
}