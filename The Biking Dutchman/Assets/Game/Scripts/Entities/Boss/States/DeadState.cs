using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private void OnEnable()
    {
        animationState.Complete += OnSpineAnimationComplete;
    }


    // Start is called before the first frame update
    void Start()
    {
        animationState.TimeScale = -1;
        animationState.SetAnimation(6, "transform", true);
    }

    public void OnSpineAnimationComplete(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.TrackIndex == 6)
        {
            StartCoroutine(Camera.main.GetComponent<FadeCamera>().FadeIn(0));
        }
    }

    public override void OnDestroy()
    {
        animationState.Complete -= OnSpineAnimationComplete;
    }
}
