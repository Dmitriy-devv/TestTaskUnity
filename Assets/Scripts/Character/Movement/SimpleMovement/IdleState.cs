using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Character.SimpleMovement
{
    public class IdleState : ISimpleMovementState
    {
        private ICharacterMovement _movement;
        private IInput _input;
        private ICharacter _character;

        public IdleState(IInput input, ICharacter character, ICharacterMovement movement)
        {
            _movement = movement;
            _input = input;
            _character = character;

            _character.CharacterAnimator.SetWalk(false);
        }

        public ISimpleMovementState Update()
        { 
            if (Mathf.Abs(_input.HorizontalAcceleration) > 0.05f || Mathf.Abs(_input.VerticalAcceleration) > 0.05f)
            {
                return new WalkState(_input, _character, _movement);
            }
            return this;
        }
    }
}