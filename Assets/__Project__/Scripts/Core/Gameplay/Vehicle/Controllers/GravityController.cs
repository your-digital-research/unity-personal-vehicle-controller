using UnityEngine;

namespace Core.Gameplay.Vehicle
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityController : MonoBehaviour
    {
        #region SERIALIZED_VARIABLES

        [Header("Settings")]
        [SerializeField] [Range(0, 250)] private float gravity;

        #endregion

        #region PRIVATE_VARIABLES

        private Rigidbody _rBody;

        #endregion

        #region MONO

        private void Awake()
        {
            Init();
        }

        private void FixedUpdate()
        {
            ApplyGravity();
        }

        #endregion

        #region PRIVATE_FUNCTIONS

        private void Init()
        {
            InitRigidbody();
        }

        private void InitRigidbody()
        {
            _rBody = GetComponent<Rigidbody>();
        }

        private void ApplyGravity()
        {
            _rBody.AddForce(Vector3.down * (gravity * _rBody.mass));
        }

        #endregion
    }
}