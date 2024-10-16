using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace StartingBudget.Patches {
    [HarmonyPatch(typeof(ShopHandler))]
    public class ShopHandlerPatch {
        [HarmonyPatch(nameof(ShopHandler.InitShop))]
        [HarmonyPostfix]
        private static void InitShopPostfix(ShopHandler __instance) {
            if (!Plugin.BoundConfig.infiniteMoney.Value) {
                Plugin.Logger.LogDebug(__instance.m_RoomStats.CurrentDay);
                Plugin.Logger.LogDebug(Plugin.BoundConfig.startingMoney.Value);
                if (PhotonNetwork.IsMasterClient && __instance.m_RoomStats.CurrentDay == 1
                && !Plugin.Registered) {
                    __instance.m_RoomStats.AddMoney(Plugin.BoundConfig.startingMoney.Value);
                    Plugin.Registered = true;
                }
            } else {
                if (PhotonNetwork.IsMasterClient) {
                    __instance.m_RoomStats.AddMoney(2147483647 - __instance.m_RoomStats.Money);
                }
            }
        }
    }
}
