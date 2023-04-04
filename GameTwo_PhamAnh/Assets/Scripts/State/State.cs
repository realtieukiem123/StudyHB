using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void OnEnter(EnemyMovement EMove)
    {
    }
    public virtual void OnUpdate(EnemyMovement EMove)
    {
    }
    public virtual void OnExit(EnemyMovement EMove)
    {
    }
}
