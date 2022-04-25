using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class TargetCamera : MonoBehaviour
{
    public void Init(CharacterData data)
    {
        transform.position = Vector3.up * data.HeadHeight;

        var cameras = transform.GetComponentsInChildren<PlayerCamera>(); //There can be an interface of Camera
        foreach (var camera in cameras)
        {
            camera.Init();
        }
    }
}
