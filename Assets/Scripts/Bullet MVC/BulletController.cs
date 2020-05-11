using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab,string layer)
        {
            BulletModel = bulletModel;

            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);


            BulletView.Initialize(this,layer);
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
     
        

        public BulletModel GetBulletModel()
        {
            return BulletModel;
     
        }


        //Function to set position of bullet.
        public void setPosition(Vector3 bulletPosition, Quaternion bulletRotation)
        {
            BulletView.transform.position = bulletPosition;
            BulletView.transform.rotation = bulletRotation;
        }


        //Destroy logic.
        public void bulletDestroy()
        {
    
             BulletService.Instance.DestroyBullet(this);
        }


        //Destroy Random Bullets.
        public void randomBulletsDestroy()
        {
            BulletService.Instance.DestroyRandom(this);

        }

        
    }

}

