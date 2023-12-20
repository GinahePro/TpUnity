using Assets.Script.BaseStateMachine;
using UnityEngine.Experimental.Rendering;


namespace Assets.Script.SphereStateMachine
{
    internal class Stoped : State<SphereOfPowerContext>
    {
        public Stoped(SphereOfPowerContext context) : base(context)
        {
        }

        public override void CustomUpdate()
        {

        }

        public override void OnEnter()
        {
            _context.rb.useGravity = false;
        }

        public override void OnLeave()
        {

        }


    }
}
