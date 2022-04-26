using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Character.SimpleMovement
{
    public class SimpleMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private float testSpeed = 1.7f;
        public float Speed { get => testSpeed; }

        private IInput _input;
        private ICharacter _character;
        private ISimpleMovementState _state;

        private bool _isInit = false;

        public void Init(IInput input, ICharacter character)
        {
            
            _input = input;
            _character = character;

            _state = new IdleState(_input, _character, this);
            _isInit = true;
        }

        private void Update()
        {
            if (!_isInit) return;
            _state = _state.Update();
        }

    }
}