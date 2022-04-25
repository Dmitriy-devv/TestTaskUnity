using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Character.SimpleMovement
{
    public class IdleState : ISimpleMovementState
    {
        private SimpleMovement _movement;
        private IInput _input;
        private CharacterController _controller;
        private CharacterAnimator _animator;

        public IdleState(IInput input, CharacterController controller, CharacterAnimator animator, SimpleMovement movement)
        {
            _movement = movement;
            _input = input;
            _controller = controller;
            _animator = animator;

            _animator.SetWalk(false);
        }

        public ISimpleMovementState Update()
        { 
            if (Mathf.Abs(_input.HorizontalAcceleration) > 0.05f || Mathf.Abs(_input.VerticalAcceleration) > 0.05f)
            {
                return new WalkState(_input, _controller, _animator, _movement);
            }
            return this;
        }
    }
}