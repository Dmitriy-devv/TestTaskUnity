using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;

namespace Character
{
    public class NetworkClothPicker : NetworkBehaviour, IPlayerClothPicker
    {
        private IInput _input;
        private IClothHandler _clothHandler;
        private List<IPlayerCloth> _playerCloths;

        public void Init(ICharacter character, IInput input)
        {
            _input = input;
            _playerCloths = character.Transform.GetComponentsInChildren<IPlayerCloth>().ToList();
            
            if (isLocalPlayer) _input.OnClothPick += ClothPick;
        }
        
        private void ClothPick()
        {
            if (_clothHandler == null) return;
            if (isServer)
            {
                ClothPickServer(_clothHandler.GetCloth());
                return;
            }

            ClothPickClient(_clothHandler.GetCloth());
        }

        [Command]
        private void ClothPickClient(ClothType clothType)
        {
            ClothPickServer(clothType);
        }

        [ClientRpc]
        private void ClothPickServer(ClothType clothType)
        {
            var cloths = _playerCloths.Where(cloth => cloth.ClothType == clothType);

            foreach (var cloth in cloths)
            {
                cloth.SetCloth(!cloth.IsDressed);
            }
        }

        //Get the key to pick cloth
        public KeyCode GetPickButton()
        {
            return _input.GetPickClothKeycode();
        }

        //Set current cloth handler
        public void SetClothHandler(IClothHandler clothHandler)
        {
            _clothHandler = clothHandler;
        }
    }
}