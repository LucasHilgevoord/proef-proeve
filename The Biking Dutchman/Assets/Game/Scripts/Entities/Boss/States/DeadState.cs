using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Camera.main.GetComponent<FadeCamera>().FadeIn(0));
    }

    public override void OnDestroy()
    {
        //throw new System.NotImplementedException();
    }
}
