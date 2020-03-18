using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    private void OnEnable()
    {
        animationState.Complete += OnSpineAnimationComplete;
    }

    private void Start()
    {
        animationState.SetAnimation(5, "war_cry_0" + Random.Range(1, 3), false);
    }

    public void OnSpineAnimationComplete(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.TrackIndex == 5)
        {
            controller.ChangeState("ATTACK");
        }
    }

    public override void OnDestroy()
    {
        animationState.ClearTracks();
        animationState.Complete -= OnSpineAnimationComplete;
    }
}
