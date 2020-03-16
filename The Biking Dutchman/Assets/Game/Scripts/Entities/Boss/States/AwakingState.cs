using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakingState : State
{
    new void Start()
    {
        base.Start();
    }

    public override void OnDestroy()
    {
        //throw new System.NotImplementedException();
    }
}
