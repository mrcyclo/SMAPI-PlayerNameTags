using System;
using HarmonyLib;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;

namespace PlayerNameTags
{
    internal sealed class ModEntry : Mod
    {
        private void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            this.Monitor.Log(message, logLevel);
        }

        public override void Entry(IModHelper helper)
        {
            Harmony harmony = new Harmony(this.ModManifest.UniqueID);
            harmony.Patch(
                original: AccessTools.Method(typeof(Farmer), nameof(Farmer.draw), new Type[] { typeof(SpriteBatch) }),
                prefix: new HarmonyMethod(typeof(FarmerPatches), nameof(FarmerPatches.draw_Postfix))
            );
        }
    }
}
