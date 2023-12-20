using Assets.Script.BaseStateMachine;
using UnityEngine;

namespace Assets.Script.PlayerStateMachine
{
    public class PlayerContext : StateContext
    {
        public PlayerSettings settings;
        public GameplaySettings gameplaySettings;
        public PlayerController controller;

        public Transform cameraVerticalRotationPoint;
        public Rigidbody rb;
        public Transform transform;

        public LayerMask whatIsGround;

        public SphereOfPower currentSphere;

        public PlayerContext(GameObject playerGameObject , PlayerSettings settings , GameplaySettings gameplaySettings, Transform cameraVerticalRotationPoint , LayerMask whatIsGround)
        {
            this.settings = settings;
            this.gameplaySettings = gameplaySettings;
            controller = PlayerController.instance;

            this.cameraVerticalRotationPoint = cameraVerticalRotationPoint;
            rb = playerGameObject.GetComponent<Rigidbody>();
            transform = playerGameObject.transform;
            this.whatIsGround = whatIsGround;
        }


    }
}
