using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.SimpleMovement;
using Character;
using Mirror;


public class Initializer : NetworkBehaviour
{
    [SerializeField] private Character.CharacterInfo _playerPrefab;
    [SerializeField] private PlayerSettingsSO _playerSettingsSO;
    [SerializeField] private TargetCamera _targetCamera;

    private IInput _input;
    private PlayerSettings _playerSettings;

    private void Start()
    {
        _input = new GameObject("InputHandler").AddComponent<KeyboardInputHandler>();

        _playerSettings = _playerSettingsSO.PlayerSettings;
    }

    [Command(requiresAuthority = false)]
    public void Spawn()
    {
        
    }

}
