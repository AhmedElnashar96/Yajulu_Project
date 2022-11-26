using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    private bool debuff = false;

    private void OnCollisionEnter(Collision other)
    {
        PlayerHealthController healthController = other.collider.GetComponent<PlayerHealthController>();

        if (healthController)
        {
            if (debuff == false)
            {
                debuff = true;
                healthController.DamageThePlayer(damageAmount);
                Destroy(gameObject);
            }
        }
    }
    private void OnEnable()
    {
        debuff = false;
    }
}
