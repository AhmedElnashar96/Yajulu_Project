using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Yajulu/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Tooltip("Speed of player when going forward.")]
    public float forwardSpeed = 5;

    [Tooltip("Speed of player when going left /right")]
    public float horizontalSpeed = 5;

    [Tooltip("Starting health of the player")]
    public int health = 100;

    [Space(20)]
    [Tooltip("The player will be rewarded with score every x amount of distance")]
    public int distanceToRewardScore = 100;

    [Tooltip("Score to be rewarded to the player")]
    public int scoreToReward = 1000;
}
