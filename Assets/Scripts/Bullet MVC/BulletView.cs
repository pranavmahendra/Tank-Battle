﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;
  

        private void Start()
        {

            Debug.Log("This is from Bullet View");
        }

        private void Update()
        {
            bulletMovement();

            destoryBullet();
        }

        //Linking view and controller.
        public void Initialize(BulletController controller)
        {
            this.bulletController = controller;
        }


        public void bulletMovement()
        {

            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }

        //Destroy bullet.
        public void destoryBullet()
        {
            Destroy(gameObject, 2f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<EnemyView>() != null)
            {
                Destroy(gameObject);
            }
            else
            {
                destoryBullet();
            }
        }

    }
}