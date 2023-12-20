
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float jumpPower;
    public float movementPower;
    public float groundDrag;
    public float airDrag;
    public float maxSpeed;
    public float MaxSpeed { get { return Mathf.Pow(maxSpeed, 2); } }

    public float playerHeight;

    public float horizontalCameraSensitivity;
    public float verticalCameraSensitivity;
}
