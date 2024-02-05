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

        #endregion
    }
}