using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

public class EnemyPatroling : Enemeystate
{
    private float timeElapsed;
   
    public float speed;
    public Coroutine coroutine;
    
    public List<Transform> goalPoints;
    private Vector3 goalPosition1;
    private Vector3 goalPosition2;
  
 
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        //collider1 = enemyView.activations[0];
        timeElapsed = 0f;
   
        //StartCoroutine(Movement(1));

        goalPosition1 = new Vector3(goalPoints[0].transform.position.x, goalPoints[0].transform.position.y, goalPoints[0].transform.position.z);
        goalPosition2 = new Vector3(goalPoints[1].transform.position.x, goalPoints[1].transform.position.y, goalPoints[1].transform.position.z);

        Debug.Log("Enemy has entered patroling state");

    }

    public override void OnExitState()
    {
        base.OnExitState();
        
        Debug.Log("Enemy has exit patroling state");
    }

    private void Update()
    {
        //movement();
    }

    public void movement()
    {
       
        Vector3 direction1 = goalPosition1 - enemyView.transform.position;
        transform.Translate(direction1.normalized * speed * Time.deltaTime);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankView>() != null && enemyView.patrolingCollider == true)
        {
            enemyView.ChangeState(enemyView.idleState);
        }
       
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TankView>() != null && enemyView.attackingCollider == true)
        {
            enemyView.ChangeState(enemyView.attackState);
        }

    }



}
