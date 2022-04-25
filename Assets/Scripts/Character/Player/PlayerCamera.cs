using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private TargetCamera _target;
        [SerializeField] private float _sensitivity;
        [SerializeField] private float maxYAngle = 90f;
        [SerializeField] private float maxDistanceZoom = 5f;
        [SerializeField] private float minDistanceZoom = 1f;

        private float _yRotation = 0f;
        private float _xRotation = 0f;

        private bool _isInit;

        public void Init(PlayerSettings playerSettings)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _sensitivity = playerSettings.cameraSensetivity;

            _isInit = true;
        }

        private void Update()
        {
            if (!_isInit) return;

            var mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

            _xRotation += mouseX;
            _yRotation -= mouseY;
            _yRotation = Mathf.Clamp(_yRotation, -maxYAngle, maxYAngle);

            transform.LookAt(_target.transform);

            //_target.transform.localRotation = Quaternion.Euler(_yRotation, _xRotation, 0f);
        }

        public Vector3 GetHorizontalRotation()
        {
            return Vector3.up * _xRotation;
        }

        public Vector3 GetVerticalRotation()
        {
            return Vector3.right * _yRotation;
        }

        public void SetDistance(float distance)
        {
            var pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x, pos.y, -distance);
        }

        public float GetMinDistance() => minDistanceZoom;
        public float GetMaxDistance() => maxDistanceZoom;
        public float GetCurrentDistance() => -transform.localPosition.z;


    }
}