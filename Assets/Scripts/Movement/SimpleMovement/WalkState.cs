using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleMovement
{
    public class WalkState : ISimpleMovementState
    {
        private SimpleMovement _movement;
        private IInput _input;
        private CharacterController _controller;
        private Animator _animator;

        public WalkState(IInput input, CharacterController controller, Animator animator, SimpleMovement movement)
        {
            _movement = movement; 
            _input = input;
            _controller = controller;
            _animator = animator;

            _animator.SetBool("Walk", true);
        }

        public ISimpleMovementState Update()
        {
            if (!(Mathf.Abs(_input.HorizontalAcceleration) > 0.05f || Mathf.Abs(_input.VerticalAcceleration) > 0.05f))
            {
                return new IdleState(_input, _controller, _animator, _movement);
            }

            Move();
            return this;
        }

        private void Move()
        {
            var horizontal = _input.HorizontalAcceleration * _controller.transform.right;
            var vertical = _input.VerticalAcceleration * _controller.transform.forward;
            var motion = (horizontal + vertical).normalized * Time.deltaTime * _movement.Speed;
            _controller.Move(motion);
        }
    }
}