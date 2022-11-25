using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    #region Variables

    #region Hidden
    [HideInInspector] public Animator animator;
    private string currentAnimation;
    #endregion

    #endregion

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Function to call for animations :  ChangeAnimationState(string);
    /// Mini Animation Manager
    /// </summary>
    public void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
