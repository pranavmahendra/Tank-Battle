using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    [RequireComponent(typeof(EnemyView))]
    public class Enemeystate : MonoBehaviour
    {
        protected EnemyView enemyView;

        private void Awake()
        {
            enemyView = this.GetComponent<EnemyView>();
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
