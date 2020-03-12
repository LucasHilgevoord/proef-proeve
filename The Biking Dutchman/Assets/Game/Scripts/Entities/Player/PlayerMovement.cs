using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cycle();
    }

    private void Cycle()
    {
        rb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed, transform.position.y);

    }
}
