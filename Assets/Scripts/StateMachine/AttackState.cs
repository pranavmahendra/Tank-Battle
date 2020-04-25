using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

public class AttackState : Enemeystate
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Tank has started attacking!");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Tank has stopped attacking!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankView>() != null)
        {
            enemyView.ChangeState(enemyView.attackState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TankView>() != null)
        {
            enemyView.ChangeState(enemyView.patrolingState);
        }
    }
}
