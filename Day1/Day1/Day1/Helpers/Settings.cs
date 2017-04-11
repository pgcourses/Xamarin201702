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
        /// Ezen a property-n kereszt�l �rj�k el a plugin-t.
        /// Ehhez kapunk egy Singleton p�ld�nyt, vagyis, az eg�sz
        /// alkalmaz�son bel�l ak�rh�nyszor k�rj�k el, mindig ugyanazt 
        /// kapjuk
        /// 
        /// A Settings k�rnyezet egy sz�t�rba (Dictionary) menti el az inform�ci�kat
        /// ehhez minden platformon saj�t implement�ci�t haszn�l.
        /// 
        /// sz�t�r: kulcs/�rt�k p�roknak a gy�jtem�nye, kulcs alapj�n tudunk benne keresni/m�dos�tani
        /// 
        /// Ezeket a t�pusokat tudjuk menteni
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
        /// R�szletesen: https://github.com/jamesmontemagno/SettingsPlugin
        /// 
        /// </summary>
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        #region Setting Constants

        //Ez lesz a sz�t�rban a kulcs
        private const string NickNameSettingsKey = "NickName_key";
        //ez meg az alap�rtelmezett �rt�k
        private static readonly string NickNameSettingsDefault = string.Empty;

        private const string NetworkOnlyIfWifiSettingsKey = "NetworkOnlyIfWifi_key";
        //ez meg az alap�rtelmezett �rt�k
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