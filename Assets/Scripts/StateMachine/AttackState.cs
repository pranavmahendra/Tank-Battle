using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

public class AttackState : Enemeystate
{
    public float speed = 2;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Tank has started attacking!");
        StartCoroutine(tankFireRate());
        
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Tank has stopped attacking!");
        StopCoroutine(StartCoroutine(tankFireRate()));
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

    public IEnumerator tankFireRate()
    {
        enemyView.enemyController.enemyTankFire(goal);
        yield return new WaitForEndOfFrame();
    }
}
