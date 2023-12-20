using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] PlayerSettings settings;
    

    public Vector2 WantedMovement = new();
    public Quaternion HorizontalCameraRotation
    {
        get
        {
            return Quaternion.Euler(0, horizontalCameraRotationAngle, 0);
        }
    }
    public Quaternion VerticalCameraRotation
    {
        get
        {
            return Quaternion.Euler(verticalCameraRotationAngle,0,0);
        }
    }    
    
    float verticalCameraRotationAngle;
    float horizontalCameraRotationAngle;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMovement(InputValue input)
    {
        WantedMovement = input.Get<Vector2>();
    }

    public delegate void InputTriggerDelegate();
    public event InputTriggerDelegate OnJumpAction ;
    void OnJump(InputValue input)
    {
        OnJumpAction?.Invoke();
        Debug.Log(OnJumpAction);
    }

    void OnCameraVertical(InputValue input)
    {
        verticalCameraRotationAngle -= input.Get<float>() * settings.verticalCameraSensitivity;
        verticalCameraRotationAngle = Mathf.Max(verticalCameraRotationAngle, -70);
        verticalCameraRotationAngle = Mathf.Min(verticalCameraRotationAngle, 70);
    }
    void OnCameraHorizontal(InputValue input)
    {
        horizontalCameraRotationAngle += input.Get<float>() * settings.horizontalCameraSensitivity;
        if (horizontalCameraRotationAngle > 360) horizontalCameraRotationAngle -= 360;
        if (horizontalCameraRotationAngle < 0) horizontalCameraRotationAngle += 360;
    }

    public InputTriggerDelegate OnMainInteractionAction;
    void OnMainInteraction()
    {
        OnMainInteractionAction?.Invoke();
    }
}
