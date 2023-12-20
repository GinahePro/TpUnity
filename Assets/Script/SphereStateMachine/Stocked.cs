using Assets.Script.BaseStateMachine;
using UnityEngine;

namespace Assets.Script.SphereStateMachine
{
    internal class Stocked : State<SphereOfPowerContext>
    {
        public Stocked(SphereOfPowerContext context) : base(context)
        {
        }

        public override void CustomUpdate()
        {

        }

        public override void OnEnter()
        {

        }

        public override void OnLeave()
        {

        }

        void OnLaunch(Vector3 launchDirection)
        {
            StateMachine.changeState(new Launched(_context, launchDirection * _context.settings.launchPower));
        }
    }
}
