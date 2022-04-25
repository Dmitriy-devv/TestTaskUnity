using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Character;

public class ClothTriggerZone : MonoBehaviour
{
    public event Action<IPlayerClothPicker> OnEnter;
    public event Action<IPlayerClothPicker> OnExit;

    public void Init()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IPlayerClothPicker>(out var clothPicker)) return;

        OnEnter?.Invoke(clothPicker);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<IPlayerClothPicker>(out var clothPicker)) return;

        OnExit?.Invoke(clothPicker);
    }
}
