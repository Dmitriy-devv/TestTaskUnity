using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleMovement;
using Character;


public class Initializer : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    public void Start()
    {
        var input = new GameObject("InputHandler").AddComponent<InputHandler>();

        //Player
        var player = Instantiate(_playerPrefab);
        player.Init();

        var movement = player.gameObject.AddComponent<SimpleMovement.SimpleMovement>();
        movement.Init(input);

    }
}
