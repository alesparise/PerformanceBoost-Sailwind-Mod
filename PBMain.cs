using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;
//poorly written by pr0skynesis (discord username)

namespace PerformanceBoost
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class PBMain : BaseUnityPlugin
    {
        // Plugin INFO
        public const string pluginGuid = "pr0skynesis.performanceboost";
        public const string pluginName = "Performance Boost";
        public const string pluginVersion = "1.0.0";

        public void Awake()
        {
            Harmony harmony = new Harmony(pluginGuid);
            
            //TouchRotateHandle - Works, reduces impact by around 70%, might not work for winches that are several child down from the boat object (the boat model)
            MethodInfo original = AccessTools.Method(typeof(TouchRotateHandle), "Update");
            MethodInfo patch = AccessTools.Method(typeof(PBPatches), "TRHPatch");
            harmony.Patch(original, new HarmonyMethod(patch));

            /*//IslandSceneryScene 
            MethodInfo original2 = AccessTools.Method(typeof(IslandStreetlightsManager), "Awake");
            MethodInfo patch2 = AccessTools.Method(typeof(PBPatches), "StaticBatcherInit");
            harmony.Patch(original2, new HarmonyMethod(patch2));
            //Does not work
            MethodInfo original2 = AccessTools.Method(typeof(GPButtonRopeWinch), "Update");
            MethodInfo patch2 = AccessTools.Method(typeof(PBPatches), "GPBRWPatch");
            harmony.Patch(original2, new HarmonyMethod(patch2));

            //Does not work
            MethodInfo original3 = AccessTools.Method(typeof(GoPointer), "FixedUpdate");
            MethodInfo patch3 = AccessTools.Method(typeof(PBPatches), "GPBRWPatch");
            harmony.Patch(original3, new HarmonyMethod(patch3));*/
        }
    }
}
