using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{

    public class Player : MonoBehaviour, ICharacter
    {
        public Transform Transform => transform;

        public CharacterAnimator CharacterAnimator => _characterAnimator;

        public CharacterController CharacterController => _characterController;

        private CharacterAnimator _characterAnimator;
        private CharacterController _characterController;

        public void Init()
        {
            var animator = GetComponent<Animator>();
            _characterAnimator = new CharacterAnimator(animator);
            _characterController = GetComponent<CharacterController>();
        }


    }
}

