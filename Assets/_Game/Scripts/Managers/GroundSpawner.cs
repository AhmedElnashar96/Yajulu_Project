using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    #region Variables

    #region Exposed
    #endregion

    #region Hidden
    [SerializeField] private List<Transform> groundtilePrefabs;
    [SerializeField] private Transform tilesParent;


    private List<Transform> tiles = new();

    private int lastUsedNum = 0;
    private Vector3 nextPosition;
    #endregion

    #endregion


    private void Start()
    {
        SpawnNewGroundtiles(transform.position);
    }



    /// Spawn 5 new tiles at each tile rea's end position
    /// Destroy Old tiles
    public void SpawnNewGroundtiles(Vector2 thisPos)
    {
        print(transform.position);
        Transform newScreen = SpawnTransform(thisPos);

        for (int i = 1; i < 5; i++)
        {
            Transform newTile = SpawnTransform(nextPosition);
            nextPosition = newTile.position + new Vector3(0, 0, 23.9f);
        }
       
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
