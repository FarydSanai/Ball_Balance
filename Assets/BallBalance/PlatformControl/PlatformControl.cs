using UnityEngine;
using UnityEngine.InputSystem;

namespace BallBalance
{
    public enum PlayerActions
    {
        Rotate,
    }
    public class PlatformControl : MonoBehaviour
    {
        private const float MaxRotaion = 0.4f;
        private float My;

        [SerializeField]
        private GameObject Ball;
        [SerializeField]
        private float RotationSensitivity;
        [SerializeField]
        private PlayerInput playerInput;

        private Vector2 DirectionValue;
        private Quaternion Rotation;
        private void Update()
        {
            HandlePlatformRotation();
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
        private void HandlePlatformRotation()
        {
            DirectionValue = playerInput.actions[PlayerActions.Rotate.ToString()].ReadValue<Vector2>();
            Rotation = Quaternion.Euler(DirectionValue.x * RotationSensitivity * Time.deltaTime,
                                        0f,
                                        DirectionValue.y * RotationSensitivity * Time.deltaTime);
            if (CheckMaxRotation(Rotation))
            {
                return;
            }
            transform.rotation *= Rotation;
        }
        private bool CheckMaxRotation(Quaternion rotaion)
        {
            if ((transform.rotation * rotaion).x > MaxRotaion ||
                (transform.rotation * rotaion).x < -MaxRotaion ||
                (transform.rotation * rotaion).z > MaxRotaion ||
                (transform.rotation * rotaion).z < -MaxRotaion)

            {
                return true;
            }
            return false;
        }
    }
}
