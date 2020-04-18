using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;

public class EnemyPatroling : Enemeystate
{
    private float timeElapsed;

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

    //private void Update()
    //{
    //    timeElapsed += Time.deltaTime;
    //    if(timeElapsed > 5f)
    //    {
    //       enemyView.ChangeState(enemyView.idleState);
    //    }
        
    //}
}
