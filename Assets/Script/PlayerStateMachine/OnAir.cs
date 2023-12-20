using Assets.Script.BaseStateMachine;
using UnityEngine;

namespace Assets.Script.PlayerStateMachine
{
    internal class OnAir : BasePlayerState
    {
        public OnAir(PlayerContext context) : base(context)
        {

        }

        public override void OnEnter()
        {
            _context.rb.drag = _context.settings.airDrag;
        }

        public override void OnLeave()
        {
            
        }

        public override void CustomUpdate()
        {
            base.CustomUpdate();

            if (Physics.Raycast(_context.transform.position, Vector3.down, _context.settings.playerHeight / 2 + 0.1f, _context.whatIsGround))
            {
                StateMachine.changeState(new Grounded(_context));
            }
        }
    }
}
