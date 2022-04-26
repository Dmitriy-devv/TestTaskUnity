using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInput
{
    public event Action OnClothPick;

    public float VerticalAcceleration { get;}
    public float HorizontalAcceleration { get;}
    public float CameraX { get;}
    public float CameraY { get;}
    public float WheelAcceleration { get;}
    public bool IsCameraFreeLook { get; }

    public KeyCode GetPickClothKeycode();
}
