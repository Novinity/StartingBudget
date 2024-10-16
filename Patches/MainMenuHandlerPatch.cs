using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace StartingBudget.Patches {
    [HarmonyPatch(typeof(MainMenuHandler))]
    public class MainMenuHandlerPatch {
        [HarmonyPatch(nameof(MainMenuHandler.Awake))]
        [HarmonyPostfix]
        private static void Awake() {
            if (Plugin.Registered) {
                Plugin.Logger.LogDebug("Returned to main menu, unregistering.");
                Plugin.Registered = false;
            }
        }
    }
}
