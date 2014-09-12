using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace bingRewards
{
    class WebClickSound
    {
        /// <summary>
        /// Enables or disables the web browser navigating click sound.
        /// </summary>
        public static bool Enabled
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current");
                string keyValue = (string)key.GetValue(null);
                return String.IsNullOrEmpty(keyValue) == false && keyValue != "\"\"";
            }
            set
            {
                string keyValue;

                if (value)
                {
                    keyValue = "%SystemRoot%\\Media\\";
                    if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor > 0)
                    {
                        // XP
                        keyValue += "Windows XP Start.wav";
                    }
                    else if (Environment.OSVersion.Version.Major == 6)
                    {
                        // Vista
                        keyValue += "Windows Navigation Start.wav";
                    }
                    else
                    {
                        // Don't know the file name so I won't be able to re-enable it
                        return;
                    }
                }
                else
                {
                    keyValue = "\"\"";
                }

                // Open and set the key that points to the file
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current", true);
                key.SetValue(null, keyValue, RegistryValueKind.ExpandString);
            }
        }
    }
}