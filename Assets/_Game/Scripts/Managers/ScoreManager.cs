using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private PlayerData playerData;

    [Space(20)]
    [Header("Events")]
    [SerializeField] private IntGameEvent distanceEvent;
    [SerializeField] private IntGameEvent scoreEvent;


    private float currentDistance = 0;
    private float oldDistance = 0;
    private float currentScore = 0;

    private int distanceToRewardScore = 0;
    private int scoreToReward = 0;
    #endregion

    #endregion

    private void Start()
    {
        distanceToRewardScore = playerData.distanceToRewardScore;
        scoreToReward = playerData.scoreToReward;

        ResetData();
    }

    private void Update()
    {
        if (!GameManager.isGameOn)
        {
            return;
        }


        currentDistance += 0.05f;
        distanceEvent?.Raise((int) currentDistance);


        UpdateScore();
    }

    private void UpdateScore()
    {
        if (currentDistance - oldDistance >= distanceToRewardScore)
        {
            currentScore += scoreToReward;
            oldDistance += distanceToRewardScore;
            scoreEvent?.Raise((int)currentScore);
        }
    }
    private void ResetData()
    {
        currentDistance = oldDistance = currentScore = 0;
    }
}
