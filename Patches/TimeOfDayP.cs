using HarmonyLib;

namespace BetterTime.Patches
{
    internal class TimeOfDayP
    {
        [HarmonyPatch(typeof(TimeOfDay))]
        private static class TimeOfDay_Update_Patch
        {
            [HarmonyPatch("Start")]
            [HarmonyPrefix]
            private static void Start_Pre(TimeOfDay __instance)
            {
                int value = BetterTime_Base.TimeSpeed.Value;
                // Make 1 hour ingame, actually be one real hour
                BetterTime_Base.mls.LogInfo($"Old TimeSpeed: {__instance.globalTimeSpeedMultiplier}");
                __instance.globalTimeSpeedMultiplier /=  value;

                BetterTime_Base.mls.LogInfo($"Value: {value}");
                BetterTime_Base.mls.LogInfo($"TimeSpeed: {__instance.globalTimeSpeedMultiplier}");
            }
        }
    }
}
