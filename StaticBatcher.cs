using UnityEngine;

namespace PerformanceBoost
{   /// <summary>
    /// Attach to an object and it should combine all child into one? Attach to scenery.
    /// I think this does nothing at best, I'll disable it for now.
    /// </summary>
    public class StaticBatcher : MonoBehaviour
    {   //Does not seem to work
        /*private void Awake()
        {
            GameObject go = gameObject;
            go.isStatic = true;
            go.transform.parent = transform;
            StaticBatchingUtility.Combine(gameObject);
            Debug.LogWarning("StaticBatcher: batched " + name);
        }*/
        private void Awake()
        {
            MeshRenderer[] meshRenderers = FindObjectsOfType<MeshRenderer>();
            Debug.LogWarning("StaticBatcher: Total Mesh Renderers: " + meshRenderers.Length);

            StaticBatchingUtility.Combine(gameObject);

            meshRenderers = FindObjectsOfType<MeshRenderer>();
            Debug.LogWarning("StaticBatcher: Total Mesh Renderers: " + meshRenderers.Length);
        }
    }
}
