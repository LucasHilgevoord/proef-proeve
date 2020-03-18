using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : StateMachine
{
    public StateID[] states = {
        new StateID("AWAKE", typeof(AwakingState), null),
        new StateID("IDLE", typeof(IdleState), null),
        new StateID("ATTACK", typeof(AttackState), null),
        new StateID("DODGE", typeof(DodgeState), null),
        new StateID("DEAD", typeof(DeadState), null),
    };

    void Start()
    {
        //Adding all states
        for (int i = 0; i < states.Length; i++)
        {
            AddState(states[i].stateName, states[i].stateScript);
        }
        ChangeState("AWAKE");
    }
}
