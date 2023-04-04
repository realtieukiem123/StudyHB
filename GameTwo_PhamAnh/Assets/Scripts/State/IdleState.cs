using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void OnEnter(EnemyMovement EMove)
    {
        EMove._animator.SetBool("fowardSpeed", false);
    }
    public override void OnUpdate(EnemyMovement EMove)
    {

        Vector3 n = new Vector3(0f, 0f, 40f);
        EMove.navMeshAgent.Move(n * 0f);
        //EMove.navMeshAgent.SetDestination(n);
    }

}
