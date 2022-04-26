using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface ICharacter
    {
        public Transform Transform { get; }
        public CharacterAnimator CharacterAnimator { get;}
        public CharacterController CharacterController { get; }
    }
}
