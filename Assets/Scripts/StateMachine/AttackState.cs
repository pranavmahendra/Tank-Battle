using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

public class AttackState : Enemeystate
{
    public float speed = 2;
    private Transform playerPos;

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
        enemyView.transform.LookAt(playerPos.position);
        enemyView.transform.Translate(0, 0, speed * Time.deltaTime);
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankView>() != null)
        {
            GameObject player = other.gameObject;
            Transform goal = player.transform;
            this.playerPos = goal;

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
        enemyView.enemyController.enemyTankFire();
        yield return new WaitForEndOfFrame();
    }
}
