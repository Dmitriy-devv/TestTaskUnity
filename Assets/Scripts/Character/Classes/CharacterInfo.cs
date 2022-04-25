using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] private Transform _meshTransform;

        public CharacterTypeSO CharacterTypeSO;
        public Transform MeshTransform => _meshTransform;
    }
}