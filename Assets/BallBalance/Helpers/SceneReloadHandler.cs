using UnityEngine;

namespace BallBalance
{
    public class SceneReloadHandler : MonoBehaviour
    {
        public static bool IsTryAgain;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}