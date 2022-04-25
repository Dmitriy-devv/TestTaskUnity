using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 1)]
public class PlayerSettingsSO : ScriptableObject
{
    [SerializeField] private PlayerSettings _playerSettings;

    public PlayerSettings PlayerSettings => _playerSettings;
}
