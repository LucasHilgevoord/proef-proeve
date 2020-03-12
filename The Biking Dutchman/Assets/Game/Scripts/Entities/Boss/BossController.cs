using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : StateMachine
{
    public StateID[] states = {
        new StateID("AWAKE", new AwakingState()),
        new StateID("IDLE", new IdleState()),
        new StateID("ATTACK", new AttackState()),
        new StateID("DODGE", new DodgeState()),
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

    new void Update()
    {
        //Updating the Update in StateMachine
        base.Update();
    }
}
