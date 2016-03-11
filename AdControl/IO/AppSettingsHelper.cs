using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace PAdControl.IO
{
    public class AppSettingsHelper
    {
        public static bool IsKeyValidate(string key)
        {
            return IsolatedStorageSettings.ApplicationSettings.Contains(key);
        }

        public static object GetObjectFormAppSettings(string key)
        {
            if (IsKeyValidate(key))
            {
                return IsolatedStorageSettings.ApplicationSettings[key];
            }
            return null;
        }

        public static string GetStringFromAppSettings(string key)
        {
            return (GetObjectFormAppSettings(key) ?? string.Empty).ToString();
        }

        public static void SaveStringToAppSettings(string key, string value)
        {
            IsolatedStorageSettings.ApplicationSettings[key] = value;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

    }
}
