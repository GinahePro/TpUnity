using System;
using UnityEngine;

namespace Assets.Script
{
    internal class SphereHolder : MonoBehaviour , IActionner
    {
        [SerializeField] Animator animator;
        [SerializeField] GameObject SpherePoint;
        
        public bool State { 
            get { return state; } 
            private set { state = value; OnStateUpdate?.Invoke(); }
        }
        bool state = false;

        public event IActionner.StateUpdate OnStateUpdate;

        void Start()
        {
            if (state)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Disable", 0, 1);
            }
        }

        private void OnTriggerEnter(Collider sphere)
        {

            if (sphere.gameObject.GetComponent<SphereOfPower>().Catch())
            {
                State = true;
                
            }
        }
    }
}
