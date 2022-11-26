using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour
{
    [SerializeField] private string wantedTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wantedTag))
        {
            Destroy(other.gameObject);
            print("Destroyed");
        }
    }
}
