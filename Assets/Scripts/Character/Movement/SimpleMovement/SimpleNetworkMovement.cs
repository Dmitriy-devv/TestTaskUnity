using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Mirror;

namespace Character.SimpleMovement
{
    public class SimpleNetworkMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private float testSpeed = 1.7f;
        public float Speed { get => testSpeed; }

        private IInput _input;
        private ISimpleMovementState _state;
        private bool _isInit = false;

        public void Init(IInput input, ICharacter character)
        {
            _input = input;
            _state = new IdleState(_input, character, this);
            _isInit = true;
        }

        private void Update()
        {
            if (!_isInit) return;

            _state = _state.Update();
        }
    }
}