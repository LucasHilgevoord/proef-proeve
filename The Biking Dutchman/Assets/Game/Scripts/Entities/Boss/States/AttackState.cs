using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public delegate void Hit();
    public static event Hit OnHit;

    private float maxDodgeTimer = 7;
    private float minDodgeTimer = 5;
    private float currentDodgeTime;

    private void OnEnable()
    {
        animationState.Complete += OnSpineAnimationComplete;
    }

    private void Start()
    {
        animationState.SetAnimation(3, "idle", true);
        currentDodgeTime = Random.Range(minDodgeTimer, maxDodgeTimer);
    }

    private void Update()
    {
        //Starting timer for dodge moment
        currentDodgeTime -= Time.deltaTime;
        if (currentDodgeTime < 0)
            controller.ChangeState("DODGE");
    }

    /// <summary>
    /// When pressed on the boss.
    /// </summary>
    void OnMouseDown()
    {
        animationState.SetAnimation(4, "damage", false);
        audioSource.PlayOneShot(controller.audioList[1].clips[Random.Range(0, 2)], 0.7F);
        audioSource.PlayOneShot(controller.audioList[1].clips[Random.Range(2, 4)], 0.7F);
        OnHit();
    }

    /// <summary>
    /// Checking if the animation is done playing.
    /// </summary>
    /// <param name="trackEntry"></param>
    public void OnSpineAnimationComplete(Spine.TrackEntry trackEntry)
    {
        //Back to idle anim after the damage anim is done
        if (trackEntry.TrackIndex == 4)
        {
            animationState.SetAnimation(4, "idle", true);
        }
    }

    public override void OnDestroy()
    {
        animationState.Complete -= OnSpineAnimationComplete;
    }
}
