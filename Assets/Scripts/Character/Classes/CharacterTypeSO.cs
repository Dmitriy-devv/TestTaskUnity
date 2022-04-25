using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "Type", menuName = "ScriptableObjects/CharacterType", order = 1)]
    public class CharacterTypeSO : ScriptableObject
    {
        public CharacterData CharacterData;
    }
}

