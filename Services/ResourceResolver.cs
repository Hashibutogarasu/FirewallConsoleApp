using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Resources.Core;
using Windows.Management.Deployment;

namespace FirewallConsoleApp.Services
{
    public static class ResourceResolver
    {
        private static readonly ConcurrentDictionary<string, string> _cache = new();
        private static readonly PackageManager _packageManager = new();

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, uint cchOutBuf, IntPtr ppvReserved);

        public static string ResolveString(string source)
        {
            return ResolveIndirectString(source);
        }

        private static string ResolveIndirectString(string source)
        {
            StringBuilder sb = new(1024);

            int result = SHLoadIndirectString(source, sb, (uint)sb.Capacity, IntPtr.Zero);

            if (result == 0)
            {
                return sb.ToString();
            }

            return source;
        }

    }
}
