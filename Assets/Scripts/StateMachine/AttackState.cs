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

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.GetComponent<TankView>() != null && enemyView.attackingCollider == true)
    //    {
    //        enemyView.ChangeState(enemyView.attackState);
    //    }
       

    //}
}
