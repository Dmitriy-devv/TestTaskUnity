using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class SimplePlayerCloth : MonoBehaviour, IPlayerCloth
    {
        [SerializeField] private ClothType _clothType;
        [SerializeField] private SkinnedMeshRenderer _naked;
        [SerializeField] private SkinnedMeshRenderer _dressed;

        [SerializeField] private bool _isDressed;

        public bool IsDressed => _isDressed;

        public ClothType ClothType => _clothType;

        public void SetCloth(bool state)
        {
            _dressed.gameObject.SetActive(state);
            _naked.gameObject.SetActive(!state);
            _isDressed = state;
        }
    }
}