using Assets.Script.BaseStateMachine;
using Assets.Script.SphereStateMachine;
using Assets.Script.PlayerStateMachine;
using UnityEngine;


namespace Assets.Script
{
    public class Game : MonoBehaviour
    {
        [SerializeField] PlayerSettings settings;
        [SerializeField] GameObject playerModel;
        [SerializeField] Transform cameraVerticalRotationPoint;
        [SerializeField] LayerMask whatIsGround;

        [SerializeField] GameplaySettings gameplaySettings;

        StateMachine playerStateMachine;

        void Start ()
        {
            Cursor.lockState = CursorLockMode.Locked;

            PlayerContext playerContext = new PlayerContext(playerModel, settings , gameplaySettings, cameraVerticalRotationPoint, whatIsGround) ;
            playerStateMachine = new StateMachine(new Grounded(playerContext));


            

        }

        void FixedUpdate ()
        {
            playerStateMachine.CustomUpdate();
        }

    }
}
