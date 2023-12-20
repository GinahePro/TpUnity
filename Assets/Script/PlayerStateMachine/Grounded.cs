using Assets.Script.BaseStateMachine;
using UnityEngine;
using UnityEngine.InputSystem.XR;


namespace Assets.Script.PlayerStateMachine
{
    public class Grounded : BasePlayerState
    {
        public Grounded(PlayerContext context) : base(context)
        {

        }

        public override void OnEnter()
        {
            _context.controller.OnJumpAction += OnJump;
            _context.rb.drag = _context.settings.groundDrag;
            base.OnEnter();
        }

        public override void OnLeave()
        {
            _context.controller.OnJumpAction -= OnJump;
        }

        public override void CustomUpdate()
        {
            base.CustomUpdate();

            if (!Physics.Raycast(_context.transform.position, Vector3.down, _context.settings.playerHeight/2 +0.1f , _context.whatIsGround))
            {
                StateMachine.changeState(new OnAir(_context));
            }
        }

        void OnJump()
        {
            _context.rb.AddForce(Vector3.up * _context.settings.jumpPower, ForceMode.Impulse);
        }
    }
}
