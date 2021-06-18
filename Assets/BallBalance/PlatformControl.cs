using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BallBalance
{
    public class PlatformControl : MonoBehaviour
    {
        private Quaternion rotX;
        private Quaternion rotZ;
        [SerializeField]
        private GameObject Ball;
        [SerializeField]
        private float RotationSensitivity;

        [SerializeField]
        private PlayerInput playerInput;
        private void Update()
        {
            HandlePlayerInput();

            if (BallIsFall())
            {
                //Lose!
                Debug.Break();
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
            Vector2 directionVal = playerInput.actions["Rotate"].ReadValue<Vector2>();

            rotX = Quaternion.Euler(directionVal.x * RotationSensitivity * Time.deltaTime, 0f, 0f);
            transform.rotation *= rotX;
            
            rotZ = Quaternion.Euler(0f, 0f, directionVal.y * RotationSensitivity * Time.deltaTime);
            transform.rotation *= rotZ;            
        }
    }
}
