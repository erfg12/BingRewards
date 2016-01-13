using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

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

    public class WebBrowserHelper
    {
        #region Definitions/DLL Imports
        /// <summary>
        /// For PInvoke: Contains information about an entry in the Internet cache
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ExemptDeltaOrReserverd
        {
            [FieldOffset(0)]
            public UInt32 dwReserved;
            [FieldOffset(0)]
            public UInt32 dwExemptDelta;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INTERNET_CACHE_ENTRY_INFOA
        {
            public UInt32 dwStructSize;
            public IntPtr lpszSourceUrlName;
            public IntPtr lpszLocalFileName;
            public UInt32 CacheEntryType;
            public UInt32 dwUseCount;
            public UInt32 dwHitRate;
            public UInt32 dwSizeLow;
            public UInt32 dwSizeHigh;
            public FILETIME LastModifiedTime;
            public FILETIME ExpireTime;
            public FILETIME LastAccessTime;
            public FILETIME LastSyncTime;
            public IntPtr lpHeaderInfo;
            public UInt32 dwHeaderInfoSize;
            public IntPtr lpszFileExtension;
            public ExemptDeltaOrReserverd dwExemptDeltaOrReserved;
        }

        // For PInvoke: Initiates the enumeration of the cache groups in the Internet cache
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "FindFirstUrlCacheGroup",
            CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstUrlCacheGroup(
            int dwFlags,
            int dwFilter,
            IntPtr lpSearchCondition,
        int dwSearchCondition,
        ref long lpGroupId,
        IntPtr lpReserved);

        // For PInvoke: Retrieves the next cache group in a cache group enumeration
        [DllImport(@"wininet",
        SetLastError = true,
            CharSet = CharSet.Auto,
        EntryPoint = "FindNextUrlCacheGroup",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindNextUrlCacheGroup(
            IntPtr hFind,
            ref long lpGroupId,
            IntPtr lpReserved);

        // For PInvoke: Releases the specified GROUPID and any associated state in the cache index file
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "DeleteUrlCacheGroup",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool DeleteUrlCacheGroup(
            long GroupId,
            int dwFlags,
            IntPtr lpReserved);

        // For PInvoke: Begins the enumeration of the Internet cache
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "FindFirstUrlCacheEntryA",
            CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstUrlCacheEntry(
            [MarshalAs(UnmanagedType.LPTStr)] string lpszUrlSearchPattern,
            IntPtr lpFirstCacheEntryInfo,
            ref int lpdwFirstCacheEntryInfoBufferSize);

        // For PInvoke: Retrieves the next entry in the Internet cache
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "FindNextUrlCacheEntryA",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindNextUrlCacheEntry(
            IntPtr hFind,
            IntPtr lpNextCacheEntryInfo,
            ref int lpdwNextCacheEntryInfoBufferSize);

        // For PInvoke: Removes the file that is associated with the source name from the cache, if the file exists
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "DeleteUrlCacheEntryA",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool DeleteUrlCacheEntry(
            IntPtr lpszUrlName);
        #endregion

        /// <summary>
        /// Clears the cache of the web browser
        /// </summary>
        public static void ClearCache()
        {
            // Indicates that all of the cache groups in the user's system should be enumerated
            const int CACHEGROUP_SEARCH_ALL = 0x0;
            // Indicates that all the cache entries that are associated with the cache group
            // should be deleted, unless the entry belongs to another cache group.
            const int CACHEGROUP_FLAG_FLUSHURL_ONDELETE = 0x2;
            const int ERROR_INSUFFICIENT_BUFFER = 0x7A;

            // Delete the groups first.
            // Groups may not always exist on the system.
            // For more information, visit the following Microsoft Web site:
            // http://msdn.microsoft.com/library/?url=/workshop/networking/wininet/overview/cache.asp            
            // By default, a URL does not belong to any group. Therefore, that cache may become
            // empty even when the CacheGroup APIs are not used because the existing URL does not belong to any group.            
            long groupId = 0;
            IntPtr enumHandle = FindFirstUrlCacheGroup(0, CACHEGROUP_SEARCH_ALL, IntPtr.Zero, 0, ref groupId, IntPtr.Zero);
            if (enumHandle != IntPtr.Zero)
            {
                bool more;
                do
                {
                    // Delete a particular Cache Group.
                    DeleteUrlCacheGroup(groupId, CACHEGROUP_FLAG_FLUSHURL_ONDELETE, IntPtr.Zero);
                    more = FindNextUrlCacheGroup(enumHandle, ref groupId, IntPtr.Zero);
                } while (more);
            }

            // Start to delete URLs that do not belong to any group.
            int cacheEntryInfoBufferSizeInitial = 0;
            FindFirstUrlCacheEntry(null, IntPtr.Zero, ref cacheEntryInfoBufferSizeInitial);  // should always fail because buffer is too small
            if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
            {
                int cacheEntryInfoBufferSize = cacheEntryInfoBufferSizeInitial;
                IntPtr cacheEntryInfoBuffer = Marshal.AllocHGlobal(cacheEntryInfoBufferSize);
                enumHandle = FindFirstUrlCacheEntry(null, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
                if (enumHandle != IntPtr.Zero)
                {
                    bool more;
                    do
                    {
                        INTERNET_CACHE_ENTRY_INFOA internetCacheEntry = (INTERNET_CACHE_ENTRY_INFOA)Marshal.PtrToStructure(cacheEntryInfoBuffer, typeof(INTERNET_CACHE_ENTRY_INFOA));
                        cacheEntryInfoBufferSizeInitial = cacheEntryInfoBufferSize;
                        DeleteUrlCacheEntry(internetCacheEntry.lpszSourceUrlName);
                        more = FindNextUrlCacheEntry(enumHandle, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
                        if (!more && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
                        {
                            cacheEntryInfoBufferSize = cacheEntryInfoBufferSizeInitial;
                            cacheEntryInfoBuffer = Marshal.ReAllocHGlobal(cacheEntryInfoBuffer, (IntPtr)cacheEntryInfoBufferSize);
                            more = FindNextUrlCacheEntry(enumHandle, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
                        }
                    } while (more);
                }
                Marshal.FreeHGlobal(cacheEntryInfoBuffer);
            }
        }
    }
}