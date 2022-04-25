using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Character.SimpleMovement
{
    public class SimpleMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private float testSpeed = 2;
        public float Speed { get => testSpeed; }

        private IInput _input;
        private CharacterAnimator _animator;
        private CharacterController _characterController;
        private ISimpleMovementState _state;

        private bool _isInit = false;

        public void Init(IInput input, ICharacter character)
        {
            
            _input = input;
            _animator = character.CharacterAnimator;
            _characterController = character.CharacterController;

            _state = new IdleState(_input,_characterController, _animator, this);
            _isInit = true;
        }

        private void Update()
        {
            if (!_isInit) return;
            _state = _state.Update();
        }

    }
}