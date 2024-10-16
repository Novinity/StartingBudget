using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace StartingBudget.Patches {
    [HarmonyPatch(typeof(RoomStatsHolder))]
    public class RoomStatsHolderPatch {
        [HarmonyPatch(nameof(RoomStatsHolder.RemoveMoney))]
        [HarmonyPrefix]
        public static bool RemoveMoneyPrefix() {
            if (Plugin.BoundConfig.infiniteMoney.Value) return false;
            return true;
        }
    }
}
