using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothHandlerUI : MonoBehaviour
{
    private readonly string pickCloth = "Pick a ";

    [SerializeField] private TMPro.TextMeshProUGUI _clothText;
    [SerializeField] private TMPro.TextMeshProUGUI _buttonText;

    public void Init()
    {
        
    }

    public void SetCloth(ClothType type)
    {
        _clothText.text = pickCloth + type;
    }

    public void SetButton(KeyCode type)
    {
        _buttonText.text = type.ToString();
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

}
