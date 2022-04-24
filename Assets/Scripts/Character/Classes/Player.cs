using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{

    public class Player : MonoBehaviour, ICharacter
    {
        [SerializeField] private PlayerCamera _camera;

        public void Init()
        {
            _camera.Init();
        }

        private void LateUpdate()
        {
            transform.localRotation = Quaternion.Euler(_camera.GetHorizontalRotation());
        }


    }
}

