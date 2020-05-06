using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.Tank;

namespace BattleTank.EnemyTank
{
    //[RequireComponent(typeof(EnemyView))]
    public class Enemeystate : MonoBehaviour
    {
        public EnemyView enemyView;
        //Remove this as we will be using collision object for chasing.
        //public TankView tankViewStates;
        //public Transform goal;


        private void Awake()
        {
            //tankViewStates = EnemyService.Instance.TankViewRef;
            //tankViewStates = TankService.Instance.tankLists[0].TankView;
            //goal = tankViewStates.transform;
        }


        public virtual void OnStateEnter()
        {
            this.enabled = true;
            
        }

        public virtual void OnExitState()
        {
            this.enabled = false;
           
        }

        public void Tick()
        {

        }

    }

}
