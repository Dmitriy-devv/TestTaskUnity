using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterAnimator
    {
        private Animator _animator;
        private readonly string _walkBool = "Walk";
        private int _isWalkingHash;

        public CharacterAnimator(Animator animator)
        {
            _animator = animator;
            _isWalkingHash = Animator.StringToHash(_walkBool);
        }

        public void SetWalk(bool state)
        {
            _animator.SetBool(_isWalkingHash, state);
        }
    }
}