using System;
using global::FirewallConsoleApp.API.Exceptions;
using LibFirewall;

namespace FirewallConsoleApp.Cli.Helpers
{
    public static class FirewallHelper
    {
        public static void EnsureInitialized()
        {
            if (!Firewall.Initialize())
            {
                throw new FirewallInitializationException();
            }
        }
    }
}
