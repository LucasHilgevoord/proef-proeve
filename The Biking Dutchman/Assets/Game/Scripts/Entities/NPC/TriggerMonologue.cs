using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonologue : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float triggerDistance = 10;

    [SerializeField, TextArea(4,3)]
    private string message;

    [SerializeField]
    private Animator animator;

    private MonologueManager monologue;

    private Transform npc;

    private float distance;

    private bool active;

    private void Start()
    {
        npc = transform;
        monologue = GetComponent<MonologueManager>();

        active = false;
    }

    private void Update() 
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        distance = npc.transform.position.x - player.transform.position.x;

        if (distance < triggerDistance && distance > -triggerDistance)
        {
            if (!active)
            {
                monologue.ActivateMonologue(true, message);
                active = true;
            }
        }
        else
        {
            animator.SetTrigger("Message");
            active = false;
        }
    }

}
