using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StartingBudget {
    class ModConfig {
        public readonly ConfigEntry<int> startingMoney;

        public ModConfig(ConfigFile cfg) {
            cfg.SaveOnConfigSet = false;

            startingMoney = cfg.Bind(
                "General",
                "StartingMoney",
                0,
                "The amount of money you will start the game with"
            );

            ClearOrphanedEntries(cfg);
            cfg.Save();
            cfg.SaveOnConfigSet = true;
        }

        static void ClearOrphanedEntries(ConfigFile cfg) {
            PropertyInfo orphanedEntriesProp = AccessTools.Property(typeof(ConfigFile), "OrphanedEntries");
            var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(cfg);
            orphanedEntries.Clear();
        }
    }
}
