using GameCore;
using HarmonyLib;
using MEC;
using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AnimatedServerTitle.Patches
{
    [HarmonyPatch(typeof(PlayerList), nameof(PlayerList.Start))]
    public static class PlayerlistPatch
    {
        public static bool Prefix(PlayerList __instance)
        {
            __instance.openKey = NewInput.GetKey(ActionName.PlayerList, KeyCode.None);
            PlayerList._anyAdminOnServer = false;
            if (!NetworkServer.active)
            {
                return false;
            }
            ConfigFile.ServerConfig.UpdateConfigValue(PlayerList._refreshRate);
            ConfigFile.ServerConfig.UpdateConfigValue(PlayerList.Title);
            return false;
        }
    }
}
