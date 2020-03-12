using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateID
{
    public string stateName;
    public State stateScript;
    public StateID(string name, State script)
    {
        stateName = name;
        stateScript = script;
    }
}

public class StateMachine : MonoBehaviour
{
    private State currentState = null;
    private Dictionary<string, State> states = new Dictionary<string, State>();

    protected void Update()
    {
        if (currentState != null) currentState.Update();
    }

    /// <summary>
    /// Add a state to the StateMachine.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="state"></param>
    protected void AddState(string id, State state)
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
        if (currentState != null) currentState.End();
        if (!states.ContainsKey(id))
        {
            currentState = null;
            return;
        }
        currentState = states[id];
        currentState.Start(this, args);
    }
}
