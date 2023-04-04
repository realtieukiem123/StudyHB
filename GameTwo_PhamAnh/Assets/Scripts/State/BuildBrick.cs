using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrick : State
{
    public override void OnEnter(EnemyMovement EMove)
    {
        EMove._animator.SetBool("fowardSpeed", true);
    }
    public override void OnUpdate(EnemyMovement EMove)
    {
        Vector3 n = new Vector3(0f, 0f, 40f);
        EMove.navMeshAgent.SetDestination(n);
        //EMove.navMeshAgent.Move(getRandomPos(EMove) * Time.deltaTime * 0.2f);
        //EMove._animator.SetBool("fowardSpeed", true);
    }
}
