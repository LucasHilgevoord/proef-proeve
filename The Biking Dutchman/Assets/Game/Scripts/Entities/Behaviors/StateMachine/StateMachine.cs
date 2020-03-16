using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateID
{
    public string stateName;
    public Type stateScript;
    public StateID(string name, Type script)
    {
        stateName = name;
        stateScript = script;
    }
}

public class StateMachine : MonoBehaviour
{
    private Component currentState = null;
    private Dictionary<string, Type> states = new Dictionary<string, Type>();

    /// <summary>
    /// Add a state to the StateMachine.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="state"></param>
    protected void AddState(string id, Type state)
    {
        states.Add(id, state);
    }

    /// <summary>
    /// Change the current state to the assigned new state.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="args"></param>
    public void ChangeState(string id, object[] args = null)
    {
        Destroy(currentState);
        if (!states.ContainsKey(id))
        {
            currentState = null;
            return;
        }
        currentState = this.gameObject.AddComponent(states[id]);
    }
}
