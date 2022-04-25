using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.SimpleMovement;
using Character;


public class Initializer : MonoBehaviour
{
    [SerializeField] private Character.CharacterInfo _playerPrefab;
    [SerializeField] private TargetCamera _targetCamera;
    public void Start()
    {
        var input = new GameObject("InputHandler").AddComponent<KeyboardInputHandler>();

        
        var info = Instantiate(_playerPrefab);

        var targetCamera = Instantiate(_targetCamera, info.transform);
        targetCamera.Init(info.CharacterTypeSO.CharacterData);

        //Player
        var player = info.gameObject.AddComponent<Player>();
        player.Init();

        var clothPicker = player.gameObject.AddComponent<SimplePlayerClothPicker>();
        clothPicker.Init(info, input, targetCamera.GetCamera());

        var rotater = player.gameObject.AddComponent<PlayerCameraRotater>();
        rotater.Init(input, player, targetCamera);

        var zoom = player.gameObject.AddComponent<PlayerCameraZoom>();
        zoom.Init(input, targetCamera);

        var movement = player.gameObject.AddComponent<SimpleMovement>();
        movement.Init(input, player);

    }
}
