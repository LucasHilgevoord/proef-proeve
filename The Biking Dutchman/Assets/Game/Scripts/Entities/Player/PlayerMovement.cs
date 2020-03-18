using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Spine.Unity;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float input;

    private bool isCycling;

    public SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState animationState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        animationState = skeletonAnimation.AnimationState;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = CrossPlatformInputManager.GetAxis("Horizontal");
        Debug.Log(input);
        if (input == -1 || input == 1)
        {
            Debug.Log("Cycle");
            Cycle();
        } else
        {
            Debug.Log("Idle");
            Idle();
        }
    }

    private void Cycle()
    {
        rb.velocity = new Vector2(input * moveSpeed, transform.position.y);
        if (!isCycling)
            if (input == 1)
                animationState.SetAnimation(1, "bike", true);
            else
                animationState.SetAnimation(1, "bike_reverse", true);

        isCycling = true;
    }

    private void Idle()
    {
        if (isCycling)
        {
            rb.velocity = Vector2.zero;
            animationState.SetAnimation(1, "idle", true);
            isCycling = false;
        }
    }
}
