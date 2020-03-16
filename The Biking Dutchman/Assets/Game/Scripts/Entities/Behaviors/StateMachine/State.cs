using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour
{
    public StateMachine controller;

    public void Start()
    {
        controller = this.gameObject.GetComponent<StateMachine>();
    }
    public abstract void OnDestroy();
}
