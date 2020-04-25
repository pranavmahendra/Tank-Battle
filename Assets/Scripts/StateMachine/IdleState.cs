using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

public class IdleState : Enemeystate
{
    //private float timeElapsed;
    //private Collider patrolingCollider;

    public override void OnStateEnter()
    {
        //patrolingCollider = enemyView.activations[0];

        base.OnStateEnter();
        //timeElapsed = 0f;
        //transform.position = new Vector3(enemyView.transform.position.x, enemyView.transform.position.y, enemyView.transform.position.z);
        Debug.Log("Tank has entered idle state");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Tank has exited idle state");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<TankView>() != null )
        {
            enemyView.ChangeState(enemyView.idleState);
        }
    }

 

}
