using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleMovement;
using Character;


public class Initializer : MonoBehaviour
{
    [SerializeField] private Character.CharacterInfo _playerPrefab;
    [SerializeField] private TargetCamera _targetCamera;
    public void Start()
    {
        var input = new GameObject("InputHandler").AddComponent<KeyboardInputHandler>();

        
        var info = Instantiate(_playerPrefab);
        //Player
        var player = info.gameObject.AddComponent<Player>();
        player.Init();

        var targetCamera = Instantiate(_targetCamera, player.transform);
        targetCamera.Init(info.CharacterTypeSO.CharacterData);

        var movement = player.gameObject.AddComponent<SimpleMovement.SimpleMovement>();
        movement.Init(input);

    }
}
