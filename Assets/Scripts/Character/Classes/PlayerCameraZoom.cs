using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerCameraZoom : MonoBehaviour
    {
        private TargetCamera _targetCamera;
        private PlayerCamera _camera;
        private IInput _input;

        private float _maxDistance;
        private float _minDistance;
        private float _currentDistance;
        private float _speed = 10f;

        public void Init(IInput input, TargetCamera targetCamera)
        {
            _input = input;
            _targetCamera = targetCamera;
            _camera = targetCamera.GetCamera();
            
            _maxDistance = _camera.GetMaxDistance();
            _minDistance = _camera.GetMinDistance();
            _currentDistance = _camera.GetCurrentDistance();
            
        }

        private void Update()
        {
            _currentDistance -= _input.WheelAcceleration * Time.deltaTime * _speed;
            _currentDistance = Mathf.Clamp(_currentDistance, _minDistance, _maxDistance);
            

            var direction = (_camera.transform.position - _targetCamera.transform.position).normalized;

            var layerMask = LayerMask.GetMask("Default");
            if (!Physics.Raycast(_targetCamera.transform.position, direction , out var raycastHit, _currentDistance, layerMask)){
                _camera.SetDistance(_currentDistance);
                return;
            }

            var distanceCut = (raycastHit.point - _targetCamera.transform.position).magnitude;
            _camera.SetDistance(distanceCut - 0.1f);

            Debug.DrawRay(_targetCamera.transform.position, raycastHit.point - _targetCamera.transform.position);
        }
    }
}