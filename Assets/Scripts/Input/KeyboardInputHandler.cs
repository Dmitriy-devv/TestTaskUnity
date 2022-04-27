using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class KeyboardInputHandler : NetworkBehaviour, IInput
{
    private readonly string verticalInput = "Vertical";
    private readonly string horizontalInput = "Horizontal";
    private readonly string mouseX = "Mouse X";
    private readonly string mouseY = "Mouse Y";
    private readonly int freeLookMouseButton = 1;
    private readonly KeyCode clothPick = KeyCode.E;

    public float VerticalAcceleration => Input.GetAxis(verticalInput);
    public float HorizontalAcceleration => Input.GetAxis(horizontalInput);

    public bool IsCameraFreeLook => Input.GetMouseButton(freeLookMouseButton);

    public float WheelAcceleration => Input.mouseScrollDelta.y;

    public float CameraX => Input.GetAxis(mouseX);

    public float CameraY => Input.GetAxis(mouseY);

    public event Action OnClothPick;

    //Get the current keycode to pick cloth
    public KeyCode GetPickClothKeycode()
    {
        return clothPick;
    }

    private void Update()
    {
        if (Input.GetKeyDown(clothPick)) OnClothPick?.Invoke();
    }



}
