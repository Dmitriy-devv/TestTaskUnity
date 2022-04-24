using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    //[RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, ICharacter
    {
        private ICharacterMovement _movement;
        private CharacterController _characterController;

        public Player()
        {

            //_characterController = GetComponent<CharacterController>();
        }

        public void Init()
        {
            
        }


    }
}

