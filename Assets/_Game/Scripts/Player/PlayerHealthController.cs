using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    #region Variables

    #region Exposed
    [HideInInspector] public bool isHurt;
    #endregion

    #region Hidden
    [SerializeField] private PlayerData playerData;
    [SerializeField] private AnimationsManager animationsManager;
    [SerializeField] private PlayerMovementController playerMovementController;

    [Space(10)]
    [SerializeField] private UnityEvent deathEvent;

    [Space(10)]
    [SerializeField] private IntGameEvent updateHealthEvent;
    private float currentHealth;
    #endregion

    #endregion

    private void Start()
    {
        currentHealth = playerData.health;
    }


    /// Damage the player by this amount
    public void DamageThePlayer(float amount)
    {
        currentHealth -= amount;
        updateHealthEvent?.Raise((int) currentHealth);

        if (currentHealth <= 0)
        {
            animationsManager.ChangeAnimationState(Constants.DEATH_ANIMATION);
            deathEvent?.Invoke();
        }
        else
        {
            if (playerMovementController.isFalling)
            {
                return;
            }

            animationsManager.ChangeAnimationState(Constants.HURT_ANIMATION);
            StartCoroutine(DelayToUseHurtAnimation());
        }
    }

    /// Wait until the animation is finished before switching to another one
    private IEnumerator DelayToUseHurtAnimation()
    {
        isHurt = true;
        yield return new WaitForSeconds(animationsManager.GetAnimationLength(Constants.HURT_ANIMATION));
        isHurt = false;
    }
}
