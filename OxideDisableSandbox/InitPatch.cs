using Harmony;

namespace OxideDisableSandbox
{
    [HarmonyPatch(typeof(Bootstrap), "StartupShared")]
    public static class Init
    {
        public static void Prefix() => DisableSandbox.Init();
    }
}
