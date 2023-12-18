using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BetterTime.Patches;
using HarmonyLib;

namespace BetterTime
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class BetterTime_Base : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.GUID);

        static BetterTime_Base Instance;

        public static ManualLogSource? mls;

        // Add a config option to set the time speed, if it was set to 1, it would take 1 minute for an hour to pass, if it was set to 40, it would take 40 minutes for an hour to pass, etc.
        public static ConfigEntry<int> TimeSpeed;



        private void Awake()
        {
            if (Instance == null) Instance = new BetterTime_Base();

            mls = BepInEx.Logging.Logger.CreateLogSource(PluginInfo.GUID);

            TimeSpeed = Config.Bind("Time", "TimeSpeed", 2, "Change the speed of time\n0.1 = Time is 10x faster\n0.5 = Time is 2x faster\n1 = Time is normal\n10 = Time is 10x slower");

            mls.LogInfo("BetterTime Loaded");

            harmony.PatchAll(typeof(BetterTime_Base));
            harmony.PatchAll(typeof(TimeOfDayP));
        }
    }

    public class PluginInfo
    {
        public const string GUID = "cookies.bettertime";
        public const string Name = "BetterTime";
        public const string Version = "1.0.0";
    }
}