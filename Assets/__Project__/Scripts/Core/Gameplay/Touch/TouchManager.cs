using System;
using UnityEngine;
using UniRx;

namespace Core.Gameplay.Touch
{
    public class TouchManager : MonoBehaviour
    {
        #region EVENTS

        public Action OnUp;
        public Action OnDragStop;
        public Action OnDragStart;
        public Action<Vector3> OnDown;
        public Action<Vector3, Vector3, Vector3> OnDrag;

        #endregion

        #region PRIVATE_VARIABLES

        private bool dragStarted;

        private Vector3 lastPosition;
        private Vector3 startPosition;
        private Vector3 deltaPosition;
        private Vector3 currentPosition;
        private Vector3 totalDeltaPosition;

        private IDisposable _touchDetectionDisposable;

        #endregion

        #region MONO

        private void Start()
        {
            Init();
        }

        #endregion

        #region PRIVATE_FUNCTIONS

        private void OnDownCallback()
        {
            startPosition = Input.mousePosition;
            lastPosition = startPosition;
            deltaPosition = Vector3.zero;

            Debug.Log("OnDown");
            OnDown?.Invoke(startPosition);
        }

        private void OnDragCallback()
        {
            currentPosition = Input.mousePosition;
            deltaPosition = currentPosition - lastPosition;
            lastPosition = currentPosition;
            totalDeltaPosition = currentPosition - startPosition;

            if (totalDeltaPosition.magnitude == 0) return;

            if (!dragStarted)
            {
                dragStarted = true;

                Debug.Log("On Drag Start");
                OnDragStart?.Invoke();
            }

            Debug.Log("On Drag");
            OnDrag?.Invoke(currentPosition, deltaPosition, totalDeltaPosition);
        }

        private void OnUpCallback()
        {
            if (dragStarted)
            {
                dragStarted = false;

                OnDragStop?.Invoke();
                Debug.Log("On Drag Stop");
            }

            deltaPosition = Vector3.zero;

            Debug.Log("On Up");
            OnUp?.Invoke();
        }

        private void Init()
        {
            Debug.Log("TouchManager -> Init()");

            DisableMultiTouch();

            StartTouchDetection();
        }

        private void DisableMultiTouch()
        {
            Input.multiTouchEnabled = false;
        }

        private void StartTouchDetection()
        {
            _touchDetectionDisposable ??= Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    CheckForTouch();
                });
        }

        private void StopTouchDetection()
        {
            _touchDetectionDisposable?.Dispose();
            _touchDetectionDisposable = null;
        }

        private void CheckForTouch()
        {
            if (Input.GetMouseButtonDown(0)) OnDownCallback();
            if (Input.GetMouseButton(0)) OnDragCallback();
            if (Input.GetMouseButtonUp(0)) OnUpCallback();
        }

        #endregion
    }
}