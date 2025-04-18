using HarmonyLib;
using UnityEngine;

namespace PerformanceBoost
{
    public class PBPatches
    {
        [HarmonyPrefix]
        private static bool TRHPatch(Transform ___rotatable)
        {   //lowers impact of TouchRotateHandle by around 75% for me
            if(___rotatable.parent != GameState.currentBoat || ___rotatable.parent.parent != GameState.currentBoat)
            {
                return false;
            }
            return true;
        }
        [HarmonyPrefix]
        private static void StaticBatcherInit(IslandSceneryScene __instance)
        {
            __instance.gameObject.AddComponent<StaticBatcher>();
            Debug.LogWarning("PerformanceBoost: added component to " + __instance.name);
        }
        [HarmonyPrefix]
        private static bool GPBRWPatch(GPButtonRopeWinch __instance)
        {   //Does not seem to have any impact
            if(__instance.transform.parent != GameState.currentBoat || __instance.transform.parent.parent != GameState.currentBoat)
            {
                return false;
            }
            return true;
        }
        [HarmonyPrefix]
        private static bool GPPatch(Transform ___pointer)
        {   //actually breaks the GoPointer 
            if (!AnyObjectsNearby(___pointer.position, 2f))
            {
                return false;
            }
            return true;
        }
        private static bool AnyObjectsNearby(Vector3 position, float radius)
        {
            int layerMask = -595973; // Adjust to match your existing layer mask
            Collider[] nearbyColliders = Physics.OverlapSphere(position, radius, layerMask);

            foreach (Collider collider in nearbyColliders)
            {
                if (collider.GetComponent<GoPointerButton>() != null)
                {
                    return true; // Found an object with GoPointerButton
                }
            }
            return false; // No relevant objects nearby
        }
    }
}
