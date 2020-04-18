using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;

public class IdleState : Enemeystate
{
    private float timeElapsed;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Tank has entered idle state");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Tank has exited idle state");
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > 5f)
        {
            enemyView.ChangeState(enemyView.patrolingState);
        }
    }
}
