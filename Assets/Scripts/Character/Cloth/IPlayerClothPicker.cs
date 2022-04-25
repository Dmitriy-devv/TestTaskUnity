using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerClothPicker
{
    public Vector3 GetCameraPosition();
    public KeyCode GetPickButton();

    public void SetClothHandler(IClothHandler clothHandler);
    
}
