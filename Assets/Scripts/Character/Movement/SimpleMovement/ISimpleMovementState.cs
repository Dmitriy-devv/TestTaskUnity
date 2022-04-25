using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.SimpleMovement
{
    public interface ISimpleMovementState
    {
        public ISimpleMovementState Update();
    }
}