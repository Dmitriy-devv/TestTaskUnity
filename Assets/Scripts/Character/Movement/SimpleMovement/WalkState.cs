using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Character.SimpleMovement
{
    public class WalkState : ISimpleMovementState
    {
        private ICharacterMovement _movement;
        private IInput _input;
        private ICharacter _character;

        public WalkState(IInput input, ICharacter character, ICharacterMovement movement)
        {
            _movement = movement; 
            _input = input;
            _character = character;

            _character.CharacterAnimator.SetWalk(true);
        }

        public ISimpleMovementState Update()
        {
            if (!(Mathf.Abs(_input.HorizontalAcceleration) > 0.05f || Mathf.Abs(_input.VerticalAcceleration) > 0.05f))
            {
                return new IdleState(_input, _character, _movement);
            }

            Move();
            return this;
        }

        private void Move()
        {
            var horizontal = _input.HorizontalAcceleration * _character.CharacterController.transform.right;
            var vertical = _input.VerticalAcceleration * _character.CharacterController.transform.forward;
            var motion = (horizontal + vertical).normalized * Time.deltaTime * _movement.Speed;
            _character.CharacterController.Move(motion);
        }
    }
}