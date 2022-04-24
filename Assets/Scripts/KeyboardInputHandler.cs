using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour, IInput
{
    private readonly string verticalInput = "Vertical";
    private readonly string horizontalInput = "Horizontal";

    public float VerticalAcceleration { get => Input.GetAxis(verticalInput); }
    public float HorizontalAcceleration { get => Input.GetAxis(horizontalInput); }
}
