using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;

        private float timeElapsed;

        private void Start()
        {
      
            //Debug.Log("This is from Bullet View");
 
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
            InitializeLayer(Layer);
            
        }

        public void InitializeLayer(string layer)
        {
            this.gameObject.layer = LayerMask.NameToLayer(layer);
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

            }
            else
            {
                DisableRandom();
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