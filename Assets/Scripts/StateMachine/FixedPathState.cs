using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class FixedPathState : Enemeystate
    {

        
        public int CurrentWP;


        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.Agent.speed = 3.5f;
            CurrentWP = 1;
          
        }


        public override void OnExitState()
        {
            base.OnExitState();
           
        }


        private void LateUpdate()
        {
            AIMovement();
        }

        public void AIMovement()
        {

            if (enemyView.Agent.remainingDistance < 1)
            {
                CurrentWP++;
                if (CurrentWP >= enemyView.waypoints.Count)
                {
                    CurrentWP = 0;
                   

                }
                enemyView.Agent.SetDestination(enemyView.waypoints[CurrentWP].transform.position);
                //Debug.Log("CurrentWP is: " + CurrentWP);
            }
        }

    }

}
