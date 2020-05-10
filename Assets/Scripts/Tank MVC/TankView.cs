using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BattleTank.EnemyTank;
using System;


namespace BattleTank.Tank
{
    public class TankView : MonoBehaviour, IDamagable
    {
        public event Action onBulletFire;

        public TankController tankController;

        public AudioSource audioSource;
        public List<AudioClip> audioClips;

        public Transform barrelTip;
        public LayerMask rayMask;

        public Material tankColor;


        public ParticleSystem particle;


        private void Start()
        {
            Instantiate(particle,this.transform.position,this.transform.rotation);
            particle.Play();

            //Debug.Log("This tank view is of " + tankController.TankModel.TankType);
            audioSource = this.GetComponent<AudioSource>();
            changeColor();

            //TankService.Instance.DustTrail(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.tankFire();
                onBulletFire?.Invoke();

     
            }

            tankController.movement();

            tankController.mouseRotation();

            
        }

        //Initialization Method.
        public void initialize(TankController tankController)
        {
            this.tankController = tankController;
            
        }


        //Collision with enemy tank.
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyView>() != null)
            {
                TankService.Instance.playerDeadEvent();
                DisableView(this);
                //SceneService.Instance.sceneRestart();

            }
        }

        private void changeColor()
        {
            tankColor.SetColor("_Color", tankController.TankModel.colorType);
        }

        //Taking damage by player.
        public void TakeDamage(BulletType bullettype, int damage)
        {
            tankController.ApplyDamage(damage);

            TankService.Instance.damageEvenet();
        }


        //Destroy view
        public void DisableView(TankView tankView)
        {
            this.tankController.playVFX();
            this.gameObject.SetActive(false);
        }
    }
}
