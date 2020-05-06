using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;
        public AudioSource audioSource;
        public List<AudioClip> audioClips;

        private float timeElapsed;

        private void Start()
        {
            //Initialization
            audioSource = this.GetComponent<AudioSource>();

            BulletService.Instance.onBulletCreated += BV_BulletCreated;
            BulletService.Instance.onBulletDestroy += BV_BulletDestroy;

            Debug.Log("This is from Bullet View");
 
        }

     
        private void BV_BulletCreated()
        {

            if(Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(audioClips[1]);
            }
        
        }

        private void BV_BulletDestroy()
        {
            
            audioSource.PlayOneShot(audioClips[2]);
        }


        private void Update()
        {
            bulletMovement();

            timeElapsed += Time.deltaTime;

            if(timeElapsed > 2)
            {
                this.bulletController.randomBulletsDestroy();
                timeElapsed = 0;
            }
            //bulletController.randomBulletsDestroy();

        }

        //Linking view and controller.
        public void Initialize(BulletController controller, string Layer)
        {
            this.bulletController = controller;
            this.gameObject.layer = LayerMask.NameToLayer(Layer);
            
        }

        //Bullet movement.
        public void bulletMovement()
        {

            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }


        //Damage
        //If fired by player, collision between bullet and enemey.
        //If fired by enemey, collision between bullet and player.
        private void OnCollisionEnter(Collision collision)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {

                damagable.TakeDamage(bulletController.GetBulletModel().BulletType, bulletController.GetBulletModel().Damage);

                //Destroy Bullet.
                this.bulletController.bulletDestroy();
                //Destroy(gameObject);


            }
        }


        ////Disable BulletView
        public void DisableViewOnCollision()
        {
           
            gameObject.SetActive(false);
            
        }

        //Disable random bullets
        public void DisableRandom()
        {

            gameObject.SetActive(false);
  
        }

        //Enable BulletView
        public void EnableView()
        {
            gameObject.SetActive(true);
        }
    }
}