using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface IPlayerCloth
    {
        public void SetCloth(bool state);
        public bool IsDressed { get; }
        public ClothType ClothType { get; }
    }
}