using UnityEngine;

namespace Core.Gameplay.Cameras
{
    public class CameraController : MonoBehaviour
    {
        #region MONO

        private void Start()
        {
            Init();
        }

        #endregion

        #region PRIVATE_FUNCTIONS

        private void Init()
        {
            Debug.Log("CameraController -> Init()");
        }

        #endregion
    }
}