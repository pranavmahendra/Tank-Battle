﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BattleTank.Tank;

namespace BattleTank.bullet
{
    public class BulletService : MonosingletonGeneric<BulletService>
    {
        private BulletModel bulletModel;
        private BulletController bulletController;
        public BulletView bulletView;
        

        public BulletScriptableObjectList bulletList;
        private BulletScriptableObject bulletScriptableObject;

        public List<BulletController> bulletsCreated = new List<BulletController>();


        private void Start()
        {

            bulletScriptableObject = ScriptableObject.CreateInstance<BulletScriptableObject>();
            Debug.Log("This message is from bullet service.");

            //Debug.Log("The bullet being created is " + CreateNewBullet(1).BulletModel.BulletType);

        }


        public BulletController CreateBullet(int index,string Layer)
        {
            bulletScriptableObject = bulletList.bullets[index];

            bulletModel = new BulletModel(bulletScriptableObject);

            bulletController = new BulletController(bulletModel, bulletView,Layer);

            
      
            bulletsCreated.Add(bulletController);

            //Initialize bulletview from health
            HealthBar.Instance.followBullet();

            return bulletController;
        }

  
        public void DestroyBullet(BulletController bulletController)
        {
            bulletController.bulletDestroy();
        }

    }

}
