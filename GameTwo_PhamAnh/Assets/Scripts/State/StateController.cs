using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    protected State currentSate;
    public void SetState(State state)
    {
        currentSate = state;
        //StartCoroutine(currentSate.Idle());
    }
}
