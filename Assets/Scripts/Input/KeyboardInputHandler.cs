using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour, IInput
{
    private readonly string verticalInput = "Vertical";
    private readonly string horizontalInput = "Horizontal";
    private readonly int freeLookMouseButton = 1;
    private readonly KeyCode clothPick = KeyCode.E;

    public float VerticalAcceleration { get => Input.GetAxis(verticalInput); }
    public float HorizontalAcceleration { get => Input.GetAxis(horizontalInput); }

    public bool IsCameraFreeLook => Input.GetMouseButton(freeLookMouseButton);

    public float WheelAcceleration => Input.mouseScrollDelta.y;

    public event Action OnClothPick;

    public KeyCode GetPickClothKeycode()
    {
        return clothPick;
    }

    private void Update()
    {
        if (Input.GetKeyDown(clothPick)) OnClothPick?.Invoke();
    }



}
