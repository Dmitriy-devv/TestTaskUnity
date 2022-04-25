using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class TargetCamera : MonoBehaviour
{
    [SerializeField] private PlayerCamera _camera;
    public void Init(CharacterData data)
    {
        transform.position = Vector3.up * data.HeadHeight;

        _camera.Init();
    }

    public PlayerCamera GetCamera()
    {
        return _camera;
    }
}
