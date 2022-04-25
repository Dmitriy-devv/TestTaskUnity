using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleMovement
{
    public class IdleState : ISimpleMovementState
    {
        private SimpleMovement _movement;
        private IInput _input;
        private CharacterController _controller;
        private Animator _animator;

        public IdleState(IInput input, CharacterController controller, Animator animator, SimpleMovement movement)
        {
            _movement = movement;
            _input = input;
            _controller = controller;
            _animator = animator;

            _animator.SetBool("Walk", false);
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