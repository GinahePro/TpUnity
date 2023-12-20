using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Behaviour
{
    public class TestActionner : MonoBehaviour, IActionner
    {
        public bool State
        {
            get { return state; }
            private set { state = value; OnStateUpdate?.Invoke(); }
        }
        bool state = false;

        public event IActionner.StateUpdate OnStateUpdate;

        public void SwitchState()
        {
            State = !state;

        }
    }
}
