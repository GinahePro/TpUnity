using System;
using UnityEngine;

namespace Assets.Script
{
    internal class Door : MonoBehaviour, IActionnable
    {
        [SerializeField] Animator animator;
        float time;
        bool open;
        void Update ()
        {

        }
        public void TurnOff()
        {
            animator.SetFloat("Speed", -1);
            float newNormalizedTime = Mathf.Min(1, animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            animator.Play("DoorOpening", 0, newNormalizedTime);
        }

        public void TurnOn()
        {
            animator.SetFloat("Speed", 1);
            float newNormalizedTime = Mathf.Max(0, animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            animator.Play("DoorOpening", 0, newNormalizedTime);
        }
    }
}
