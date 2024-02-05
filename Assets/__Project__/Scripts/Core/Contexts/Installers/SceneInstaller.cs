using Core.Gameplay.Cameras;
using Core.Gameplay.Touch;
using UnityEngine;
using Zenject;

namespace Core.Contexts
{
    public class SceneInstaller : MonoInstaller
    {
        #region SERIALIZED_VARIABLES

        [Header("Managers")]
        [SerializeField] private TouchManager touchManager;

        [Header("Controllers")]
        [SerializeField] private CameraController cameraController;

        #endregion

        #region OVERRIDDEN_FUNCTIONS

        public override void InstallBindings()
        {
            BindManagers();
        }

        #endregion

        #region PRIVATE_FUNCTIONS

        private void BindManagers()
        {
            Container.Bind<TouchManager>().FromComponentInNewPrefab(touchManager).AsSingle();
        }

        private void BindControllers()
        {
            Container.Bind<CameraController>().FromComponentInNewPrefab(cameraController).AsSingle();
        }

        #endregion
    }
}