using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : Singleton<GroundSpawner>
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private List<Transform> groundtilePrefabs;
    [SerializeField] private Transform tilesParent;


    private List<Transform> tiles = new();
    private int lastUsedNum = 0;

    #endregion

    #endregion


    /// Spawn new tile at last tile's end position
    /// Destroy Old tiles
    public void SpawnNewGroundtiles(Vector3 thisPos)
    {
        SpawnTransform(thisPos);
    }


    /// Spawn groundtile prefab at this position
    private Transform SpawnTransform(Vector3 pos)
    {
        int selectedNum = PickRandomNumber();
        Transform newTile = Instantiate(groundtilePrefabs[selectedNum], pos, Quaternion.identity, tilesParent);
        return newTile;
    }

    /// Pick Random Screen number and make sure it's different than the last picked random number
    private int PickRandomNumber()
    {
        List<int> validChoices = new();

        for (int i = 0; i < groundtilePrefabs.Count; i++)
        {
            if (i != lastUsedNum)
            {
                validChoices.Add(i);
            }
        }

        int randomNum = Random.Range(0, (validChoices.Count));
        lastUsedNum = validChoices[randomNum];
        return validChoices[randomNum];
    }

}
