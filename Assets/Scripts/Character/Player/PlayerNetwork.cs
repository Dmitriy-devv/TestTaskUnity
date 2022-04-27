using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Character.SimpleMovement;

namespace Character
{
    public class PlayerNetwork : NetworkBehaviour, ICharacter
    {
        public Transform Transform => transform;
        public CharacterAnimator CharacterAnimator => _characterAnimator;

        public CharacterController CharacterController => _characterController;

        [SerializeField] private TargetCamera _targetCamera;
        [SerializeField] private CharacterInfo _info;
        [SerializeField] private PlayerSettingsSO _playerSettingsSO;

        private CharacterAnimator _characterAnimator;
        private CharacterController _characterController;
        private IInput _input;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _characterController = GetComponent<CharacterController>();
            _input = GetComponent<IInput>();

            var playerSettings = _playerSettingsSO.PlayerSettings;
            var animator = GetComponent<Animator>();
            _characterAnimator = new CharacterAnimator(animator);

            var clothPickerLocal = GetComponent<NetworkClothPicker>();
            clothPickerLocal.Init(this, _input);

            if (!isLocalPlayer)
            {
                Destroy(_characterController);
                return;
            }
            
            var targetCamera = Instantiate(_targetCamera, transform);
            targetCamera.Init(_info.CharacterTypeSO.CharacterData, playerSettings, _input);

            var rotater = gameObject.AddComponent<PlayerCameraRotater>();
            rotater.Init(_input, this, targetCamera);

            var zoom = gameObject.AddComponent<PlayerCameraZoom>();
            zoom.Init(_input, targetCamera, playerSettings);

            var movement = gameObject.AddComponent<SimpleNetworkMovement>();
            movement.Init(_input, this);

        }
    }
}