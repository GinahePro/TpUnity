using Assets.Script.BaseStateMachine;
using UnityEngine;


namespace Assets.Script.PlayerStateMachine
{
    public abstract class BasePlayerState : State<PlayerContext>
    {
        protected BasePlayerState(PlayerContext context) : base(context)
        {

        }
        public override void OnEnter()
        {
            _context.controller.OnMainInteractionAction = OnMainIntreraction;
        }
        public override void CustomUpdate()
        {
            Vector3 movementForce = Vector3.zero;
           // Debug.Log(_context.rb.velocity.magnitude);
            movementForce += _context.controller.WantedMovement.y * _context.transform.forward;
            movementForce += _context.controller.WantedMovement.x * _context.transform.right;

            Vector3 newVelocity = _context.rb.velocity + movementForce * _context.settings.movementPower * Time.fixedDeltaTime / _context.rb.mass;

            if(newVelocity.sqrMagnitude > _context.settings.MaxSpeed)
            {
                float a = 0;
                ScaleBToGetMagAPlusB(_context.rb.velocity, movementForce * _context.settings.movementPower * Time.fixedDeltaTime / _context.rb.mass, _context.settings.maxSpeed, out a);
                movementForce = (a * movementForce * _context.settings.movementPower);
            }
            else
            {
                movementForce *= _context.settings.movementPower;
            }

            

            
            _context.rb.AddForce(movementForce, ForceMode.Force);
            _context.transform.rotation = _context.controller.HorizontalCameraRotation;
            _context.cameraVerticalRotationPoint.localRotation = _context.controller.VerticalCameraRotation;

        }
        
  
        void OnMainIntreraction()
        {
            if (_context.currentSphere == null) Recall();
            Throw();
        }
        void Throw()
        {
            Ray ray = new Ray(_context.cameraVerticalRotationPoint.position, _context.cameraVerticalRotationPoint.forward);
            RaycastHit hit = new();
            LayerMask mask = _context.gameplaySettings.SphereLayerMask;
            float maxDist = _context.gameplaySettings.maxSphereInteractionDistance;
            if (Physics.Raycast(ray, out hit ,maxDist,mask))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        void Recall()
        {

        }

        public static bool ScaleBToGetMagAPlusB(Vector3 A, Vector3 B, float mag, out float alpha)
        {
            alpha = 0;

            //Impossible : magnitude positive
            if (mag < 0)
                return false;

            //Impossible de scaler B qui est nul
            if (mag > 0 && B.sqrMagnitude == 0)
                return false;

            float a = B.sqrMagnitude;
            float b = 2 * Vector3.Dot(A, B);
            float c = A.sqrMagnitude - (mag * mag);

            float delta = (b * b) - 4 * a * c;

            //impossible
            if (delta < 0)
                return false;

            float racDelta = delta > 0 ? Mathf.Sqrt(delta) : delta;
            alpha = (-b + racDelta) / (2 * a);

            return true;
        }
    }
}


