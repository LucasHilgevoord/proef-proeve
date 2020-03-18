using UnityEngine;
using System.Collections;
using Spine.Unity;

public abstract class State : MonoBehaviour
{
    public StateMachine controller;
    public SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState animationState;
    public AudioSource audioSource;

    public void Awake()
    {
        controller = this.gameObject.GetComponent<StateMachine>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        animationState = skeletonAnimation.AnimationState;
        audioSource = GetComponent<AudioSource>();
    }

    public abstract void OnDestroy();
}
