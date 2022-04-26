using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public struct PosMessage : NetworkMessage
{
    public Vector3 position;
}
