using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Character
{
    public class SimplePlayerClothPicker : MonoBehaviour, IPlayerClothPicker
    {
        private IInput _input;
        private PlayerCamera _camera;
        private IClothHandler _clothHandler;

        private List<IPlayerCloth> _playerCloths;
        
        public void Init(CharacterInfo info, IInput input, PlayerCamera camera)
        {
            _input = input;
            _camera = camera;

            _playerCloths = info.GetComponentsInChildren<IPlayerCloth>().ToList();

            _input.OnClothPick += ClothPick;
        }

        private void ClothPick()
        {
            if (_clothHandler == null) return;

            var clothType = _clothHandler.GetCloth();

            var cloths = _playerCloths.Where(cloth => cloth.ClothType == clothType);

            foreach (var cloth in cloths)
            {
                cloth.SetCloth(!cloth.IsDressed);
            }
        }

        public Vector3 GetCameraPosition()
        {
            return _camera.transform.position;
        }

        public KeyCode GetPickButton()
        {
            return _input.GetPickClothKeycode();
        }

        public void SetClothHandler(IClothHandler clothHandler)
        {
            _clothHandler = clothHandler;
        }
    }
}