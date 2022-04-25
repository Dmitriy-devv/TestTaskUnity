using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleMovement
{
    public interface ISimpleMovementState
    {
        public ISimpleMovementState Update();
    }
}