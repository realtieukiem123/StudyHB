using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBrickState : State
{
    //private Animator _animator;
    public float _x;
    public float _y;
    public float _z;
    public override void OnEnter(EnemyMovement EMove)
    {
        //base.OnEnter();
        EMove._animator.SetBool("fowardSpeed", true);
    }
    public override void OnUpdate(EnemyMovement EMove)
    {
        //base.OnUpdate();
        MoveToBrickClosest(EMove);
        //_animator.GetComponent<Animator>()
    }
    public override void OnExit(EnemyMovement EMove)
    {
        //base.OnExit();
        //EMove._animator.SetBool("fowardSpeed", false);
    }

    public Vector3 getRandomPos(EnemyMovement EMove)
    {
        _x = Random.Range(-10f, 10f);
        _z = Random.Range(-10f, 10f);
        Vector3 newPos = new Vector3(_x, _y, _z);
        return newPos;
    }
    public void MoveToBrickClosest(EnemyMovement EMove)
    {
        //CreateListBrickClosest(botController);
        EMove.navMeshAgent.SetDestination(getRandomPos(EMove));
        //EMove.navMeshAgent.Move(getRandomPos(EMove) * Time.deltaTime * 0.2f);
        //EMove._animator.SetBool("fowardSpeed", true);
    } 

}
