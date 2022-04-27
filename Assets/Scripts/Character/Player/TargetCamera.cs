using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Mirror;

public class TargetCamera : MonoBehaviour
{
    [SerializeField] private PlayerCamera _camera;
    public void Init(CharacterData data, PlayerSettings playerSettings, IInput input)
    {
        transform.position = Vector3.up * data.HeadHeight;

        _camera.Init(playerSettings, input);
    }
    //Get the attached camera to this target
    public PlayerCamera GetCamera()
    {
        return _camera;
    }
}
