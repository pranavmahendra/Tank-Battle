using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

public class EnemyPatroling : Enemeystate
{
    public float speed = 2;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        

        Debug.Log("Enemy has entered patroling state");

    }

    public override void OnExitState()
    {
        base.OnExitState();
        
        Debug.Log("Enemy has exit patroling state");
    }

    private void Update()
    {
        enemyView.transform.LookAt(goal.position);
        enemyView.transform.Translate(0, 0, speed * Time.deltaTime);
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankView>() != null)
        {
            enemyView.ChangeState(enemyView.patrolingState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TankView>() != null)
        {
            enemyView.ChangeState(enemyView.idleState);
        }
    }

}
