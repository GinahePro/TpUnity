using Assets.Script.BaseStateMachine;
using UnityEngine;

namespace Assets.Script.SphereStateMachine
{
    public class SphereOfPowerContext : StateContext
    {
        public GameObject SphereOfPower;
        public Rigidbody rb;
        public GameplaySettings settings;
        public SphereOfPowerContext() { }

        public delegate void Interaction();
        public Interaction OnInteract;

        public delegate bool CatchDelegate();
        public CatchDelegate Catch;
    }
}
