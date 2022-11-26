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


    ///  Get the length of this animation
    public float GetAnimationLength(string _animName)
    {
        RuntimeAnimatorController animatiorController = animator.runtimeAnimatorController;
        float animLength = 0;

        for (int i = 0; i < animatiorController.animationClips.Length; i++)                 // For all animations
        {
            if (animatiorController.animationClips[i].name == _animName)        // If it has the same name as wanted clip
            {
                animLength = animatiorController.animationClips[i].length;
            }
        }

        return animLength;
    }

}
