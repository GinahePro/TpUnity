
using UnityEngine;

namespace Assets.Script
{
    [CreateAssetMenu(fileName = "GameplaySettings", menuName = "ScriptableObjects/GaemplaySettings", order = 2)]
    public class GameplaySettings : ScriptableObject
    {
        public float maxSphereInteractionDistance;
        public LayerMask SphereLayerMask;

        public float launchPower;
    }
}
