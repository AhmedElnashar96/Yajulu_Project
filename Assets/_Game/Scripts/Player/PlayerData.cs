using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Yajulu/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float forwardSpeed = 5;
    public float horizontalSpeed = 5;
    public float health = 100;
}
