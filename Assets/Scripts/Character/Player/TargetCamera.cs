using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class TargetCamera : MonoBehaviour
{
    [SerializeField] private PlayerCamera _camera;
    public void Init(CharacterData data, PlayerSettings playerSettings)
    {
        transform.position = Vector3.up * data.HeadHeight;

        _camera.Init(playerSettings);
    }

    public PlayerCamera GetCamera()
    {
        return _camera;
    }
}
