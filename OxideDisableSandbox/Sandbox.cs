using Oxide.Core;

namespace OxideDisableSandbox
{
    public sealed class DisableSandbox
    {
        public string Name => "Sandbox";
        public string Author => "RFC1920";
        public VersionNumber Version => new VersionNumber(1, 0, 1);

        public static bool isconsole;
        private static bool debug = true;

        public static void Init()
        {
            LogDebug("Disable Sandbox loaded.");
        }

        private static void LogDebug(string debugTxt)
        {
            if(debug) Interface.Oxide.LogDebug(debugTxt);
        }
    }
}
