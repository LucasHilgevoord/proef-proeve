using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakingState : State
{
    public GameObject test;

    private void OnEnable()
    {
        animationState.Complete += OnSpineAnimationComplete;
    }

    void Start()
    {
        animationState.SetAnimation(0, "inactive", false);
        animationState.AddAnimation(1, "transform", false, 1f);
        audioSource.PlayOneShot(controller.audioList[0].clips[0], 0.7F);
    }

    public override void OnDestroy()
    {
        animationState.Complete -= OnSpineAnimationComplete;
    }

    public void OnSpineAnimationComplete(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.TrackIndex == 1)
            controller.ChangeState("ATTACK");
    }

}
