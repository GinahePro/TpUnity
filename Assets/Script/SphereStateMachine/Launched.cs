using Assets.Script.BaseStateMachine;
using UnityEngine;

namespace Assets.Script.SphereStateMachine
{
    internal class Launched : State<SphereOfPowerContext>
    {
        Vector3 launchInpulse;
        public Launched(SphereOfPowerContext context ,Vector3 launchInpulse) : base(context)
        {
            this.launchInpulse = launchInpulse;
        }

        public override void CustomUpdate()
        {

        }

        public override void OnEnter()
        {
            _context.rb.useGravity = true;
            _context.rb.AddForce(launchInpulse, ForceMode.Impulse);
        }

        public override void OnLeave()
        {

        }
    }
}
