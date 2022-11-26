using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextTile : MonoBehaviour
{
    private bool debuff = false;
    [SerializeField] private Transform nextSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnCollider"))
        {
            if (!debuff)
            {
                debuff = true;
                GroundSpawner.Instance.SpawnNewGroundtiles(nextSpawnPoint);
            }
        }
    }
}
