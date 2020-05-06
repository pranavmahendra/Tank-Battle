using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;
using System;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        public EnemyController enemyController;

        private Enemeystate currentState;

        public Transform enemyBarrelTip;
        public LayerMask rayMask;

        public AudioSource audioSource;
        public List<AudioClip> audioClips;
       
        public List<GameObject> waypoints;
        public Transform goalPosition;
        public int CurrentWP;

        private NavMeshAgent Agent;

        [SerializeField]
        public IdleState idleState;
        [SerializeField]
        public EnemyPatroling patrolingState;
        [SerializeField]
        public AttackState attackState;


        private void Start()
        {
            EnemyService.Instance.onDamageTaken += Instance_onDamageTaken;
            EnemyService.Instance.onDeathEvent += Instance_onDeathEvent;

            Agent = this.GetComponent<NavMeshAgent>();
            waypoints = WaypointService.Instance.Points;
            audioSource = GetComponent<AudioSource>();

            CurrentWP = UnityEngine.Random.Range(0, waypoints.Count);
          
            //StartCoroutine(randomNumber());

        }

        private void Instance_onDeathEvent()
        {
           audioSource.PlayOneShot(audioClips[0]);
        }

        private void Instance_onDamageTaken()
        {
            audioSource.PlayOneShot(audioClips[0]);
        }


        private void Update()
        {
            //_enemyController.EnemyZMovement();
                    //AIMovement();
           // wayPointsTransformUpdate();

        }


        private void wayPointsTransformUpdate()
        {
            goalPosition = waypoints[CurrentWP].transform;
            Debug.Log(goalPosition.name);
        }


        public void initialize(EnemyController enemyController)
        {
            this.enemyController = enemyController;
           
        }

        //Destroy enemy on collision with bullet.
        public void TakeDamage(BulletType bullettype, int damage)
        {
            
            Debug.Log("Taking damage " + damage);
            
            enemyController.ApplyDamage(damage);
            
          
            EnemyService.Instance.onDamageEvent();
        }

        public void ChangeState(Enemeystate newState)
        {
            if (currentState != null)
            {
                currentState.OnExitState();
            }

            currentState = newState;

            currentState.OnStateEnter();
        }

        //public void enemyDestroyView(EnemyView enemyView)
        //{ 
        //    Destroy(enemyView.gameObject);
        //    enemyView = null;
        //}

        public void enemyViewDisable()
        {
            gameObject.SetActive(false);
        }

        public void enemyViewEnabled()
        {
            gameObject.SetActive(true);
        }

        //  IEnumerator randomNumber()
        //{
        //    CurrentWP = UnityEngine.Random.Range(0, waypoints.Count);
        //    Debug.Log(CurrentWP);
        //    yield return new WaitForEndOfFrame();
        //}

        public void AIMovement()
        {
            if (Agent.remainingDistance < 1)
            {
                CurrentWP++;
                if(CurrentWP >= waypoints.Count)
                {
                    CurrentWP = UnityEngine.Random.Range(0, waypoints.Count);
                    Debug.Log("New current WP is: " + CurrentWP);
                    
                }
                Agent.SetDestination(waypoints[CurrentWP].transform.position);
                //Debug.Log("CurrentWP is: " + CurrentWP);
            }
        }

      


    }
}