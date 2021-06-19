using UnityEngine;
using UnityEngine.InputSystem;

namespace BallBalance
{
    public class PlatformControl : MonoBehaviour
    {
        private const float MaxRotaion = 0.4f;
        [SerializeField]
        private GameObject Ball;
        [SerializeField]
        private float RotationSensitivity;
        [SerializeField]
        private PlayerInput playerInput;

        private Quaternion rotX;
        private Quaternion rotZ;
        private Vector2 DirectionValue;
        private void Update()
        {
            HandlePlayerInput();
            if (BallIsFall())
            {
                PopupWindowControl.Instance.EnableTryAgain();
            }
        }
        private bool BallIsFall()
        {
            if (Ball.transform.position.y < -3f)
            {
                return true;
            }
            return false;
        }
        private void HandlePlayerInput()
        {
            DirectionValue = playerInput.actions["Rotate"].ReadValue<Vector2>();

            rotX = Quaternion.Euler(DirectionValue.x * RotationSensitivity * Time.deltaTime, 0f, 0f);
            if (CheckMaxRotation(rotX))
            {
                return;
            }
            transform.rotation *= rotX;
            
            rotZ = Quaternion.Euler(0f, 0f, DirectionValue.y * RotationSensitivity * Time.deltaTime);
            if (CheckMaxRotation(rotZ))
            {
                return;
            }
            transform.rotation *= rotZ;            
        }
        private bool CheckMaxRotation(Quaternion rot)
        {
            if ((transform.rotation * rot).x > MaxRotaion ||
                (transform.rotation * rot).x < -MaxRotaion)
            {
                return true;
            }
            if ((transform.rotation * rot).z > MaxRotaion ||
                (transform.rotation * rot).z < -MaxRotaion)
            {
                return true;
            }
            return false;
        }
    }
}
