using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

namespace Character
{
    public class ClothTriggerZone : MonoBehaviour
    {
        //On enter in trigger zone
        public event Action<IPlayerClothPicker> OnEnter;
        //On exit in trigger zone
        public event Action<IPlayerClothPicker> OnExit;

        private void OnTriggerEnter(Collider other)
        {
            
            if (!other.TryGetComponent<IPlayerClothPicker>(out var clothPicker)) return;
            if (!other.TryGetComponent<NetworkIdentity>(out var identity)) return;
            if (!identity.isLocalPlayer) return;
            OnEnter?.Invoke(clothPicker);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<IPlayerClothPicker>(out var clothPicker)) return;
            if (!other.TryGetComponent<NetworkIdentity>(out var identity)) return;
            if (!identity.isLocalPlayer) return;
            OnExit?.Invoke(clothPicker);
        }
    }
}