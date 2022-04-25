using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    public float VerticalAcceleration { get;}
    public float HorizontalAcceleration { get;}
    public bool IsCameraFreeLook { get; }
}
