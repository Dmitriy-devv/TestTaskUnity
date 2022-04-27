using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class ClothHandlerUI : MonoBehaviour
    {
        private readonly string pickCloth = "Pick a ";

        [SerializeField] private TMPro.TextMeshProUGUI _clothText;
        [SerializeField] private TMPro.TextMeshProUGUI _buttonText;

        //Update ui cloth type
        public void SetCloth(ClothType type)
        {
            _clothText.text = pickCloth + type;
        }
        //Update button to pick cloth
        public void SetButton(KeyCode type)
        {
            _buttonText.text = type.ToString();
        }
        //Set active the current ui element
        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

    }
}