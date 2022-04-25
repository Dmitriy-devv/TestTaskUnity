using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerCameraRotater : MonoBehaviour
    {
        private IInput _input;
        private ICharacter _character;
        private PlayerCamera _camera;
        private TargetCamera _targetCamera;

        private bool _isInit = false;

        public void Init(IInput input, ICharacter character, TargetCamera targetCamera)
        {
            _input = input;
            _character = character;
            _targetCamera = targetCamera;
            _camera = targetCamera.GetCamera();
            
            _isInit = true;
        }

        private void Update()
        {
            if (!_isInit) return;

            _targetCamera.transform.localRotation = Quaternion.Euler(_camera.GetVerticalRotation());

            if (!_input.IsCameraFreeLook)
            {
                _character.Transform.localRotation = Quaternion.Euler(_camera.GetHorizontalRotation());
                return;
            }

            _targetCamera.transform.localRotation = Quaternion.Euler(_camera.GetHorizontalRotation());
        }
    }
}