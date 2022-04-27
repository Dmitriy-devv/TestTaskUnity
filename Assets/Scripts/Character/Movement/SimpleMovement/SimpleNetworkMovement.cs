using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Mirror;

namespace Character.SimpleMovement
{
    public class SimpleNetworkMovement : MonoBehaviour, ICharacterMovement
    {
        public float Speed { get => _speed;}
        private float _speed;
        private IInput _input;
        private ISimpleMovementState _state;
        private bool _isInit = false;

        public void Init(IInput input, ICharacter character, CharacterData data)
        {
            _input = input;
            _state = new IdleState(_input, character, this);
            _speed = data.SpeedMovement;
            _isInit = true;
        }

        private void Update()
        {
            if (!_isInit) return;

            _state = _state.Update();
        }
    }
}