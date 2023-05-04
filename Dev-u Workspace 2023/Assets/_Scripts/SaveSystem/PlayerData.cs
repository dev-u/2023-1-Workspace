using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    
    public Vector3 PlayerPosition;

    public PlayerData() { }
    public PlayerData(Vector3 playerPosition) { PlayerPosition = playerPosition; }

}
