using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace StartingBudget.Patches {
    [HarmonyPatch(typeof(SurfaceNetworkHandler))]
    public class SurfaceNetworkHandlerPatch {
        [HarmonyPatch(nameof(SurfaceNetworkHandler.FailedQuota))]
        [HarmonyPostfix]
        public static void FailedQuotaPostfix() {
            if (Plugin.Registered) {
                Plugin.Logger.LogDebug("Failed quota, unregistering...");
                Plugin.Registered = false;
            }
        }
    }
}
