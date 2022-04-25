using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class SimpleClothHandler : MonoBehaviour, IClothHandler
    {
        [SerializeField] private ClothTriggerZone _triggerZone;
        [SerializeField] private ClothType _clothType;
        [SerializeField] private ClothHandlerUI _clothHandlerUI;

        private IPlayerClothPicker _clothPicker;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _triggerZone.OnEnter += OnEnterTrigger;
            _triggerZone.OnExit += OnExitTrigger;
            _triggerZone.Init();

            _clothHandlerUI.Init();
            _clothHandlerUI.SetCloth(_clothType);
            _clothHandlerUI.SetActive(false);

        }

        private void OnEnterTrigger(IPlayerClothPicker clothPicker)
        {
            _clothPicker = clothPicker;

            _clothHandlerUI.SetButton(_clothPicker.GetPickButton());
            _clothHandlerUI.SetActive(true);
            _clothPicker.SetClothHandler(this);
        }

        private void OnExitTrigger(IPlayerClothPicker clothPicker)
        {
            _clothHandlerUI.SetActive(false);
            _clothPicker.SetClothHandler(null);

            _clothPicker = null;
        }

        public ClothType GetCloth()
        {
            return _clothType;
        }

        private void Update()
        {
            if (_clothPicker == null) return;

            _clothHandlerUI.transform.LookAt(_clothPicker.GetCameraPosition());

        }
    }
}